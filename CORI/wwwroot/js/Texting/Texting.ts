namespace CORI.Texting {


    export function SendText() {

        var result = confirm("Are you sure you want to send this message?");

        if (result) {
            let selectedItems : any = <kendo.ui.MultiSelect>$("#PhoneNumbers").data("kendoMultiSelect").dataItems();
            let students = [];

            for (var i = 0; i < selectedItems.length; i++) {
                students.push({
                    Id : selectedItems[i].id,
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
                $("#textMessage").val("");
            });
        }
    }
}