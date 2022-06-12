function SmartAlert(msg, title, type, position = "toast-top-full-width") {
    //toast - top - right
    if (position === null || !position || position === undefined) {
        position = "toast-top-full-width";
    }
    toastr[type](msg, "", {
        positionClass: position,
        closeButton: false,
        progressBar: false,
        preventDuplicates: $('#toastr-prevent-duplicates').prop('checked'),
        newestOnTop: true,
        timeOut: 5000,
        rtl: $('body').attr('dir') === 'rtl' || $('html').attr('dir') === 'rtl'
    });
}