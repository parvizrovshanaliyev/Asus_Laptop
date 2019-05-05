$(document).ready(function () {

    $('a.delete').confirm({
        title: "Delete",
        content: "Are you sure to delete?",
        buttons: {
            Yes: {
                btnClass: 'btn-danger', // class for the button
                action: function (Yes) {
                    location.href = this.$target.attr("href");
                }
            },
            no: {

                btnClass: 'btn-success',
            }
        }
    });
});