 
function deleteComment(commentId) {
    // Show a confirmation dialog using SweetAlert2
    Swal.fire({
        title: 'Are you sure you want to delete this commente?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            // User confirmed deletion
            $.ajax({
                type: 'POST',
                url: '/User/RemoveComment',
                data: { commentId: commentId },
                success: function (result) {
                    // Remove the comment from the UI
                    $(`#comment-${commentId}`).remove();
                    // Show a success message
                    Swal.fire('Deleted!', 'Your comment has been deleted.', 'success');
                },
                error: function (xhr, status, error) {
                    // Handle any errors that occurred during the deletion
                    Swal.fire('Error deleting comment: ' + error, 'error');
                }
            });
        } else {
            // User canceled deletion
            Swal.fire('Your comment is safe!', 'info');
        }
    });
}
