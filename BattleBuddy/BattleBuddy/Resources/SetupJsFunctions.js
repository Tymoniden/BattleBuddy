function generateUid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
        .replace(/[xy]/g, function (c) {
            const r = Math.random() * 16 | 0,
                v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
}

function getEntries() {
    var entries = [];
    $("#double_column_sheets .wh40k_unit_sheet > table > thead.unit_header > tr:nth-child(1) > td:nth-child(2)").each(function(index, element){
        var uid = generateUid();
        $(element).attr("id", "uid_" + uid);

        entries.push({ "Name" : $(element).text(), "Uid" : uid });
    });

    return entries;
};

