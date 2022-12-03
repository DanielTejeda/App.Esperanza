(function (agencia) {
    agencia.success = successReload;
    //agencia.limpiarFiltros = limpiarFiltros;
    agencia.searchByFilter = searchByFilter;

    /*INICIO - Propiedades para trabajar el Signal-R*/
    agencia.hub = {}; //objeto vacío
    agencia.lstIds = []; //matriz vacía
    agencia.lstUserIds = [];
    agencia.lstUserNames = [];
    agencia.addAgenciaId = addAgenciaId;
    agencia.removeAgenciaId = removeAgenciaId;
    agencia.validate = validate;
    /*FIN - Propiedades para trabajar el Signal-R*/

    connectToHub(); //Signal-R llamada para activar el hub de lado del cliente (categoria.hub)
    initPaginacion();

    return agencia;

    function successReload(data, option) {
        if (data.includes != null && (data.includes("createForm") || data.includes("editForm") || data.includes("deleteForm"))) {
            $(".modal-body").html(data);
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'No se logró completar la acción, vuelva a intentar',
                showConfirmButton: true,
                showCloseButton: true,
                timer: 15000 //milisegundos
            })
        }
        else {
            appEsperanza.closeModal(data, option);

            //Llamada a Singal-R para comunicar a todos los usuarios de que actualicen su grilla (dataTable)
            alertUpdate();
        }
    }
    
    function initPaginacion() {
        $('#AgenciaTable').DataTable({
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "autoWidth": false,
            "responsive": true,
            "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
        }).buttons().container().appendTo('#AgenciaTableContainer .col-md-6:eq(0)');
    }

    function searchByFilter() {
        var url = '/Agencia'
        console.log(url);

        //llamada ajax de tipo get
        /*
        $.get(url, function (data) {
            $('#agenciaList').html(data);
            initPaginacion();
        })
        */
        //location.reload();
        setTimeout('location.reload()', 1750);

    }

    /*INICIO - Funciones del SignalR (trabajo con Hub): */
    function addAgenciaId(idAgencia) {
        agencia.hub.server.addAgenciaId(idAgencia, agencia.userName, agencia.userId);
    }

    function removeAgenciaId(idAgencia) {
        agencia.hub.server.removeAgenciaId(idAgencia);
    }
    function alertUpdate() {
        agencia.hub.server.alertUpdate();
    }

    function connectToHub() {
        agencia.hub = $.connection.agenciaHub;
        /*Registro de los métodos del Hub del lado del cliente:*/
        agencia.hub.client.agenciaStatus = agenciaStatus; //este método será consumido por el Hub del Servidor
        agencia.hub.client.updateListTable = updateListTable;
        console.log(agencia.hub);
    }

    function agenciaStatus(lstAgenciaIds, lstUserIds, lstUserNames) {
        console.log(lstAgenciaIds);
        console.log(lstUserIds);
        console.log(lstUserNames);
        agencia.lstIds = lstAgenciaIds;
        agencia.lstUserIds = lstUserIds;
        agencia.lstUserNames = lstUserNames;
    }

    function updateListTable() {
        console.log("Llamado de la actualización del table por Signal-R")
        searchByFilter();
    }

    function validate(idAgencia) {
        agencia.recordInUse = (agencia.lstIds.indexOf(idAgencia) > -1)
        if (agencia.recordInUse) {
            $('#inUse').attr('hidden', false); //para mostrar (remover el hidden) la alerta
            //$('#inUse').removeAttr('hidden'); //para mostrar (remover el hidden) la alerta
            $("#btn-save").html("<h2> El usuario actualizador es: " + agencia.lstUserNames[agencia.lstIds.indexOf(idAgencia)]);
        }
    }

    /*FIN - Funciones del SignalR (trabajo con Hub): */


})(window.agencia = window.agencia || {});