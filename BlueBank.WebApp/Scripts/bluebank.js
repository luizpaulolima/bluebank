// Função que inicializa todas as máscaras numéricas
// Para utilizar, basta adicionar a máscara desejada como uma classe no CSS
function inicializaMascarasNumericas() {
    $(".inteiro_10").numeric({ decimal: ",", negative: false, precision: 10, scale: 0 });
    $(".decimal_18_2").numeric({ decimal: ",", negative: false, precision: 20, scale: 2 });
}

//http://www.campusmvp.net/blog/asp-net-mvc-3-and-the-coma-in-decimals
function corrigeValidacaoParaVirgula() {
    $.validator.methods.number = function (value, element) {
        value = floatValue(value);
        return this.optional(element) || !isNaN(value);
    }
    $.validator.methods.range = function (value, element, param) {
        value = floatValue(value);
        return this.optional(element) ||
               (value >= param[0] && value <= param[1]);
    }

    function floatValue(value) {
        return parseFloat(value.replace(",", "."));
    }

    jQuery.extend(jQuery.validator.methods, {
        date: function (value, element) {
            return this.optional(element) || /^\d\d?\/\d\d?\/\d\d\d?\d?$/.test(value);
        }
    });
}