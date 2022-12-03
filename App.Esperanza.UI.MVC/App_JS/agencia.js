(function (agencia) {
    agencia.success = successReload;
    //agencia.searchByFilter = searchByFilter;

    /*
    $('#CreationDateVenta').daterangepicker({
        timePicker: true,
        startDate: moment().startOf('hour'),
        endDate: moment().startOf('hour').add(32, 'hour'),
        locale: {
            format: 'DD/MM/YYYY'
        }
    })
    */

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
    
    /*FFFFFFFFFFFFFFFFFFFF
    function searchByFilter() {
        var ventaId = document.getElementById("ventaId").value;
        var ventaIdCliente = $("#ventaIdCliente").val();
        var ventaCreationDate = $("#CreationDateVenta").val();

        console.log(ventaId);
        console.log(ventaIdCliente);
        console.log(ventaCreationDate);

        if (ventaId == '') ventaId = '-';
        if (ventaIdCliente == '') ventaIdCliente = '0';

        var url = '/Venta/ListByFilters/' + ventaId + '/' + ventaIdCliente;
        console.log(url);

        //llamada ajax de tipo get
        $.get(url, function (data) {
            $('#ventaList').html(data);
            initPaginacion();
        })

    }
    */
    // FFFFFFFFFFFFFFFFFFFF
})(window.agencia = window.agencia || {});