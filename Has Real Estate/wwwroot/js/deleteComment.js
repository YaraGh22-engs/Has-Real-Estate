$(document).ready(function () {
    var del = $('.yy');
    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'Are you sure that you need to delete this Comment?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/User/RemoveComment/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'Deleted!',
                            'Comment has been deleted.',
                            'success'
                        );
                        // // $("#div1").fadeOut();
                        // $(`#comment-${commentId}`).remove();
                        // btn.parents('div').fadeOut();
                        del.fadeOut();
                        // $(this).parents('div').closest('.yy').fadeOut();
                        console.log("Hello world!");
                    },
                    error: function () {
                        swal.fire(
                            'Oooops...',
                            'Something went wrong.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});