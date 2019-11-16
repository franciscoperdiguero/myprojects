
const responses = {
    zero: "Esta relación, tiene muy pocas posibilidades de funcionar, aún así, trabajando muy duro por ambas partes será posible conseguirlo.",
    fifteen: "La compatibilidad no es ideal en esta relación, será necesario bastante esfuerzo mutuo para que la relación salga a flote y funcione.",
    thirtyFive: "Las posibilidades de que esta relación funcione, no son demasiado altas, pero podría darse el caso si los dos realmente queréis y estáis preparados para hacer sacrificios uno por el otro.",
    fortyFive: "Vuestra compatibilidad no es muy alta pero tampoco muy baja, veo probabilidades de un amor duradero si llegáis a confiar el uno en el otro.",
    fiftyFive: "Veo un posible flechazo, que podría convertirse en amor verdadero si ciertas condiciones están a favor. La compatibilidad es media, por lo que esta relación podría funcionar.",
    seventy: "Veo una pareja con una compatibilidad aceptable, lo cual puede dar lugar a un amor muy pasional, pero de frágil consistencia. Con mutuo esfuerzo, podréis llegar a vivir momentos muy felices.",
    eightyFive: "Existe muy buena compatibilidad entre estas dos personas. Una relación amorosa sería bastante fructífera y daría lugar a momentos muy felices. Con cierto esfuerzo y comprensión funcionará.",
    ninetyFive: "Esta relación tiene muchas posibilidades de funcionar, pero eso no significa que no tengas que trabajar para conseguirlo. Recuerda que toda relación necesita que la pareja pase tiempo juntos, hablando...",
    hundred: "¡Esta relación puede ser un éxito rotundo!, con poner un poco de cada parte todo irá sobre ruedas y seréis muy felices."
};

module.exports = {

    countChars: function (str1, str2) {
        var combinedStrings = str1.toLowerCase() + "loves" + str2.toLowerCase();

        var strAllChars = "";
        var strCount = "";
        for (var i = 0; i < combinedStrings.length; i++) {
            if (strAllChars.indexOf(combinedStrings.charAt(i)) < 0) {
                var count = 0;
                for (var j = 0; j < combinedStrings.length; j++) {
                    if (combinedStrings.charAt(i) === combinedStrings.charAt(j)) {
                        count++;
                    }
                }
                strAllChars += combinedStrings.charAt(i);
                strCount += count.toString();
            }
        }
        return strCount;
    },

    shortenNumber: function (str) {

        var shortenString = "";

        if (str.length >= 2) {
            var int1 = parseInt(str.charAt(0));
            var int2 = parseInt(str.charAt(str.length - 1));

            shortenString = (int1 + int2).toString() + module.exports.shortenNumber(str.substring(1, str.length - 1));
        } else {
            return str;
        }
        return shortenString;
    },

    calculatePercentage: function (str1, str2) {
        var shortString = module.exports.countChars(str1, str2);
        var output = shortString;
        var lineBreak = 0;
        do {
            output += "\n";
            lineBreak++;
            shortString = module.exports.shortenNumber(shortString);
            if (shortString.length === 2) {
                output += "\n";
                lineBreak++;
            }
            output += shortString;
        } while (shortString.length > 2);

        var finalOut = output.split("\n")[lineBreak];

        return finalOut;
    },

    getResults: function (value) {
        if (value === 0) {
            return responses.zero;
        } else if (value >= 1 && value < 15) {
            return responses.fifteen;
        } else if (value >= 15 && value < 35) {
            return responses.thirtyFive;
        } else if (value >= 35 && value < 45) {
            return responses.fortyFive;
        } else if (value >= 45 && value < 55) {
            return responses.fiftyFive;
        } else if (value >= 55 && value < 70) {
            return responses.seventy;
        } else if (value >= 70 && value < 85) {
            return responses.eightyFive;
        } else if (value >= 85 && value < 95) {
            return responses.ninetyFive;
        } else {
            return responses.hundred;
        }
    }
}   