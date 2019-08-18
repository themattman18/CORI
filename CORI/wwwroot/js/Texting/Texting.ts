namespace CORI.Texting {

    declare var LoadingSpinner;

    export function SendText() {
        let selectedItems: any = <kendo.ui.MultiSelect>$("#PhoneNumbers").data("kendoMultiSelect").dataItems();

        if (selectedItems.length > 0) {
            var result = confirm("Are you sure you want to send this message to " + selectedItems.length + " students?");

            if (result) {

                LoadingSpinner.Show(true);

                let students = [];

                for (var i = 0; i < selectedItems.length; i++) {
                    students.push({
                        Id: selectedItems[i].id,
                        FirstName: selectedItems[i].firstName,
                        LastName: selectedItems[i].lastName,
                        Phone: selectedItems[i].phone

                    });
                }

                let msg = $("#textMessage").val() as string;
                let url = $("#textingControls").data("texting-url") as string;

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
}