var CORI;
(function (CORI) {
    var Texting;
    (function (Texting) {
        function SendText() {
            var phone = $("#phoneNumber").val();
            var msg = $("#message").val();
            var url = $("#textingControls").data("texting-url");
            $.ajax({
                url: url,
                type: "POST",
                data: { phoneNumber: phone, message: msg }
            });
        }
        Texting.SendText = SendText;
    })(Texting = CORI.Texting || (CORI.Texting = {}));
})(CORI || (CORI = {}));
//# sourceMappingURL=Texting.js.map