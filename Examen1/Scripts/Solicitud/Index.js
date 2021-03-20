var ClickNew = function () {
    window.location.href = "Solicitud/Edit";
}

var ClickUpdate = function (id) {
    window.location.href = "Solicitud/Edit/" + id;
}

var ClickDelete = function (id) {

    Swal.fire({
        title: 'Estas seguro de que desea eliminar el registro?',
        //text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Borrar Registro!'
    }).then((result) => {
        if (result.isConfirmed) {

            window.location.href = "Solicitud/Delete/" + id;

        }
    });


}

if (IsLoading) Loading.fire("Cargando Datos...");
$(document).ready(function () {
    $('#GridSolicitud').DataTable();

    setTimeout(function () {
        if (IsLoading) Loading.close();
    }, 500)
});