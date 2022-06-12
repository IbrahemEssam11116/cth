function BindCombo(DropDownID, DataSource, SelectorOPtional) {
    var Items = '';
    $.each(DataSource, function (i, item) {
        Items += '<option value="' + item.value + '"selected="' + item.selected + '">' + item.text + '</option>';
    });
    if (SelectorOPtional) {
        $(SelectorOPtional + '#' + DropDownID).empty();
        $(SelectorOPtional + '#' + DropDownID).append(Items);
    }
    else {
        //$('#' + DropDownID).empty();
        $('#' + DropDownID).append(Items);
    }
}