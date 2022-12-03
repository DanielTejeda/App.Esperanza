(function (appEsperanza) { //

    //permite que la funcion puedar ser llamada desde cualquier js 
    appEsperanza.getModal = getModalContent;
    appEsperanza.closeModal = closeModal;
    appEsperanza.mostrarAlerta = mostrarAlerta;

    return appEsperanza;

    //funcion para que se muestre el modal en el div modal-body
    function getModalContent(url) {
        $.get(url, function (data) {
            $(".modal-body").html(data);
        })
    }

    function closeModal(data, option) {
        $("button[data-dismiss='modal']").click();
        //$("#modal-container").hide();
        $('.modal-body').html("");

        mostrarAlerta(data, option);
    }

    function mostrarAlerta(data, option) {
        if (option === 'create') {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Se creó el registro exitosamente con el ID: ' + data,
                showConfirmButton: true,
                showCloseButton: true,
                timer: 15000 //milisegundos
            })
        }
        if (option === 'edit') {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Se editó el registro exitosamente con el ID: ' + data,
                showConfirmButton: true,
                showCloseButton: true,
                timer: 15000 //milisegundos
            })
        }
        else if (option === 'delete') {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Se inactivó el registro exitosamente con el ID: ' + data,
                showConfirmButton: true,
                showCloseButton: true,
                timer: 15000 //milisegundos
            })
        }
    }

})(window.appEsperanza = window.appEsperanza || {}); // forma de que al llamar al js se inicialice el codigo interno