namespace CORI.Texting {


    export function SendText() {

        let phone = $("#phoneNumber").val() as string;
        let msg = $("#message").val() as string;
        let url = $("#textingControls").data("texting-url") as string;

        $.ajax({
            url: url,
            type: "POST",
            data: { phoneNumber: phone, message: msg }
        });

    }
}