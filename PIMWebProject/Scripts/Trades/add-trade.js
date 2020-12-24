$('.number').keypress(function (event) {

    if ((event.which != 46 || $(this).val().indexOf('.') != -1) &&
        (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});

$(document).on("input", '.number', function (event) {
    $(this).val(fixDecimalIn($(this).val()));
    //alert("Sim");

});


$(document).ready(function () {
    changeOperation(".operation-type");
});

function changeOperation(obj) {

    var value = $(obj).val();

    $(".sell-field").prop("disabled", false);
    $(".sell-field-select").prop("disabled", false);
    $(".buy-field").prop("disabled", false);
    $(".buy-field-select").prop("disabled", false);
    $(".btn-insert-trade").prop("disabled", false);
    $(".rate-field-select").val("default").change().prop("disabled", false);
    $(".rate-field").val("").prop("disabled", false);

    switch (value) {
        case "1"://TROCA

            break;
        case "2"://ENTRADA

            $(".sell-field").val("").prop("disabled", true);
            $(".sell-field-select").val("default").change().prop("disabled", true);
            break;
        case "3"://SAÍDA
            $(".buy-field").val("").prop("disabled", true);
            $(".buy-field-select").val("default").change().prop("disabled", true);
            break;
        default:
            $(".btn-insert-trade").prop("disabled", true);
            $(".sell-field").prop("disabled", true);
            $(".sell-field-select").prop("disabled", true);
            $(".buy-field").prop("disabled", true);
            $(".buy-field-select").prop("disabled", true);
            $(".btn-insert-trade").prop("disabled", true);
            $(".rate-field-select").val("default").change().prop("disabled", true);
            $(".rate-field").val("").prop("disabled", true);
            break;
    }
}

$(".operation-type").change(function () {
    changeOperation($(this));
})

$(document).on("click", ".btn-insert-trade", function (e) {
    $(this).prop("disabled", true);
    e.preventDefault();

    var operation_value = $(".operation-type").val();

    switch (operation_value) {
        case "1":
            tradeValuesConfirm();
            break;
        case "2":
            if (ValuesConfirm(".buy-field-select", ".buy-field")) {
                var selected_buy = $(".buy-field-select").val();
                var buy = $(".buy-field").val();
                var rate = $(".rate-field").val() != "" ? $(".rate-field").val() : " ";
                var selected_rate = $(".rate-field-selected").val() != "default" ? $(".rate-field-selected").val() : " ";
                createTrade(buy, selected_buy, " ", " ", rate, selected_rate);
            }
            break;
        case "3":
            if (ValuesConfirm(".sell-field-select", ".sell-field")) {
                var selected_sell = $(".sell-field-select").val();
                var sell = $(".sell-field").val();
                var rate = $(".rate-field").val() != "" ? $(".rate-field").val() : " ";
                var selected_rate = $(".rate-field-selected").val() != "default" ? $(".rate-field-selected").val() : " ";
                createTrade(" ", " ", sell, selected_sell, rate, selected_rate);
            }
            break;
        default:
            break;
    }
    $(this).prop("disabled", false);

});

function ValuesConfirm(select, field, sellorbuy) {
    var selected = $(select).val();
    var field_set = $(field).val();
    var rate = $(".rate-field").val();
    var selected_rate = $(".rate-field-select").val();

    if (isValidDate($(".date-change").val())) {

        if (selected !== "default") {
            if (field_set != null && field_set != undefined && field_set != "") {

                if (rate != null && rate != undefined && rate != "") {
                    if (selected_rate === "default") {
                        alert("Selecione a moeda utilizada para a Taxa.");
                    }
                    else {
                        if (isDecimal(field_set) && isDecimal(rate)) {
                            return true;
                        }
                        else {
                            alert("Os campos devem estar no formato monetário (####.####).");
                        }
                    }
                }
                else {
                    //alert("tudo ok sem taxa");
                    if (isDecimal(field_set)) {
                        //console.log(fixDecimal(field_set));
                        return true;
                    }
                    else {
                        alert("Os campos devem estar no formato monetário (####.####).");
                    }
                }
            }
            else {
                alert("Preencha o valor do campo de " + sellorbuy + ".");
            }
        }
        else {
            alert("Selecione o Tipo de moeda.");
        }
    }
    else {
        alert("A data digitada não é válida.")
        $(".data-change").val("");
    }
    return false;
}

function tradeValuesConfirm() {
    var selected_buy = $(".buy-field-select").val();
    var selected_sell = $(".sell-field-select").val();
    var buy = $(".buy-field").val();
    var sell = $(".sell-field").val();
    var rate = $(".rate-field").val();
    var selected_rate = $(".rate-field-select").val();

    if (isValidDate($(".date-change").val())) {
        if (selected_buy !== "default" && selected_sell !== "default") {
            if (buy != null && buy != undefined && buy != "") {
                if (sell != null && sell != undefined && sell != "") {
                    if (rate != null && rate != undefined && rate != "") {
                        if (selected_rate === "default") {
                            alert("Selecione a moeda utilizada para a Taxa.");
                        }
                        else {
                            if (isDecimal(buy) && isDecimal(sell) && isDecimal(rate)) {
                                createTrade(buy, selected_buy, sell, selected_sell, rate, selected_rate);

                            }
                            else {
                                alert("Os campos devem estar no formato monetário (####.####).");
                            }
                        }
                    }
                    else {
                        //alert("tudo ok sem taxa");
                        if (isDecimal(buy) && isDecimal(sell)) {
                            createTrade(buy, selected_buy, sell, selected_sell, "", "");
                        }
                        else {
                            alert("Os campos devem estar no formato monetário (####.####).");
                        }
                    }
                }
                else {
                    alert("Preencha o valor do campo de Venda.");
                }
            }
            else {
                alert("Preencha o valor do campo de Compra.");
            }
        }
        else {
            alert("Selecione o Tipo de moeda de Venda e Compra.");
        }
    } else {
        alert("A data digitada não é válida");
        $(".date-change").val("");
    }
}

function isDecimal(text) {
    var checkVal = text;
    if (checkVal.match("^[0-9]{0,7}((\.|,)[0-9]{1,8}|[0-9]{0,8})$")) {
        return true;
    } else {
        return false;
    }
}

function createTrade(buy, coin_buy, sell, coin_sell, rate, coin_rate) {

    var TradeTemp = {
        trade: {
            Tipo: $(".operation-type").val(),
            ValorCompra: fixDecimal(buy),
            MoedaCompra: coin_buy,
            ValorVenda: fixDecimal(sell),
            MoedaVenda: coin_sell,
            ValorTaxa: fixDecimal(rate),
            MoedaTaxa: coin_rate,
            Comentario: $(".text-commentary").val() != "" ? $(".text-commentary").val() : " ",
            DataTroca: $(".date-change").val()
        }
    };
    var url = "";
    $.ajax({
        url: "CreateTrade",
        data: JSON.stringify(TradeTemp),
        method: "POST",
        dataType: "JSON",
        contentType: "application/json",
        success: function (data) {
            url = data.url;
            window.location.href = url;

        }, error: function () {
            alert("Ocorreu um erro ao tentar cadastrar uma nova Troca.");
            window.location.reload = true;
        }
    });

}

function isValidDate(s) {
    if (s.length > 0) {
        var bits = s.split('/');
        var d = new Date(bits[2] + '/' + bits[1] + '/' + bits[0]);
        return !!(d && (d.getMonth() + 1) == bits[1] && d.getDate() == Number(bits[0]));
    } else return false;
}

function fixDecimalIn(text) {
    var $this = text,
        dot = $this.indexOf('.'),
        before, after;

    if (dot >= 1) {
        before = $this.substr(0, dot).slice(0, 6);
        after = $this.substr(dot, $this.lenght).slice(1, 8);
        console.log(`${before}.${after}`);
        $this = `${before}.${after}`;
    }
    else {
        if (dot == 0) {
            $this = $this.slice(0, 9);
        }
        else
            $this = $this.slice(0, 8);
    }

    return $this;
}

function fixDecimal(text) {

    var $this = text;
    if ($this.length > 0 && $this != " ") {
        var dot = $this.indexOf('.');

        switch (dot) {
            case 0:
                $this = `00${$this}`;
                break;
            case -1:
                $this = `${$this}.00`;
                break;
        }
    } else $this = " ";

    return $this;
}