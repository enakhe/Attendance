$(function () {
    $("#example1").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false, "ordering": true, "searching": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print"]
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
});