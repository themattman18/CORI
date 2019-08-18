var CORI;
(function (CORI) {
    var Texting;
    (function (Texting) {
        function SendText() {
            var selectedItems = $("#PhoneNumbers").data("kendoMultiSelect").dataItems();
            if (selectedItems.length > 0) {
                var result = confirm("Are you sure you want to send this message to " + selectedItems.length + " students?");
                if (result) {
                    LoadingSpinner.Show(true);
                    var students = [];
                    for (var i = 0; i < selectedItems.length; i++) {
                        students.push({
                            Id: selectedItems[i].id,
                            FirstName: selectedItems[i].firstName,
                            LastName: selectedItems[i].lastName,
                            Phone: selectedItems[i].phone
                        });
                    }
                    var msg = $("#textMessage").val();
                    var url = $("#textingControls").data("texting-url");
                    $.ajax({
                        url: url,
                        type: "POST",
                        data: { studentsToText: students, message: msg }
                    }).done(function (e) {
                        LoadingSpinner.Show(false);
                        $("#textMessage").val("");
                    });
                }
            }
        }
        Texting.SendText = SendText;
    })(Texting = CORI.Texting || (CORI.Texting = {}));
})(CORI || (CORI = {}));
//# sourceMappingURL=Texting.js.map