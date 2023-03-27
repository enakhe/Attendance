$(function () {
    $("#example1").DataTable({
        "responsive": true, "lengthChange": true, "autoWidth": true, "ordering": true, "searching": true,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"], "paging": true, "info": true,
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
});