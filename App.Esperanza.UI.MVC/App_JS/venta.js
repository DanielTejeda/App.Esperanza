(function (venta) {
    venta.success = successReload;
    venta.searchByFilter = searchByFilter;
    venta.searchByFilterPend = searchByFilterPend;
    venta.limpiarFiltros = limpiarFiltros;

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

    return venta;

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
        else if (data.includes != null && data.includes("ErrorPage")) {
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
            searchByFilter(); // quitar si falla
        }
    }
    
    function initPaginacion() {
        $('#ventaTable').DataTable({
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "autoWidth": false,
            "responsive": true,
            "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
        }).buttons().container().appendTo('#ventaTableContainer .col-md-6:eq(0)');
    }
    
    //FFFFFFFFFFFFFFFFFFFF
    function searchByFilter() {
        var ventaId = document.getElementById("ventaId").value;
        var ventaIdCliente = $("#ventaIdCliente").val();
        var ventaIdAsesor = $("#ventaIdAsesor").val();

        console.log(ventaId);
        console.log(ventaIdCliente);
        console.log(ventaIdAsesor);

        if (ventaId == '') ventaId = '-';
        if (ventaIdCliente == '') ventaIdCliente = '0';
        if (ventaIdAsesor == '') ventaIdAsesor = '0';

        var url = '/Venta/ListByFilters/' + ventaId + '/' + ventaIdCliente + '/' + ventaIdAsesor;
        console.log(url);

        //llamada ajax de tipo get
        $.get(url, function (data) {
            $('#ventaList').html(data);
            initPaginacion();
        })

    }

    function searchByFilterPend() {
        var ventaPendId = document.getElementById("ventaPendId").value;
        var ventaPendIdCliente = $("#ventaPendIdCliente").val();
        var ventaPendIdAsesor = $("#ventaPendIdAsesor").val();

        console.log(ventaPendId);
        console.log(ventaPendIdCliente);
        console.log(ventaPendIdAsesor);

        if (ventaPendId == '') ventaPendId = '-';
        if (ventaPendIdCliente == '') ventaPendIdCliente = '0';
        if (ventaPendIdAsesor == '') ventaPendIdAsesor = '0';

        var url = '/Venta/ListByFiltersPend/' + ventaPendId + '/' + ventaPendIdCliente + '/' + ventaPendIdAsesor;
        console.log(url);

        //llamada ajax de tipo get
        $.get(url, function (data) {
            $('#ventaPendList').html(data);
            initPaginacion();
        })

    }
    function limpiarFiltros() {
        $("#ventaId").val("");
        $("#ventaIdCliente").val("");
        $("#ventaIdAsesor").val("");

        $("#ventaPendId").val("");
        $("#ventaPendIdCliente").val("");
        $("#ventaPendIdAsesor").val("");
    }
    
    // FFFFFFFFFFFFFFFFFFFF
})(window.venta = window.venta || {});