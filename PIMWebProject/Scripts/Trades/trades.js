$(document).on("dblclick", "tr.tr-trade-row", function () {
    var tr = $("tr.tr-info-row[data-id = '" + $(this).attr("data-id") + "'] .container-info");

    var enabled = $(tr).hasClass("enabled") ? true : false;

    $(tr).removeClass(enabled ? "enabled" : "disabled").addClass(enabled ? "disabled" : "enabled");
});

$(document).on("change", ".ckb-selected-row",function () {

    const count = $(".ckb-selected-row:checked").length;

    if (count == 1) {
        //$(".btn-change-trade").prop("disabled", false);
        $(".btn-remove-trade").prop("disabled", false);
    }
    else {
        if (count > 1) {
            //$(".btn-change-trade").prop("disabled", true);
            $(".btn-remove-trade").prop("disabled", false);
        }
        else {
            //$(".btn-change-trade").prop("disabled", true);
            $(".btn-remove-trade").prop("disabled", true);
        }
    }
});

$(".btn-remove-trade").on("click", function () {
    var obj = {
        trade: []
    }

    $(".ckb-selected-row:checked").each(function (value, index) {

        obj.trade.push({
            Id: $(this).closest("tr.tr-trade-row").attr("data-id"),
            UserId: $("#hidden-id-user").attr("data-id")
        });
    });

    //console.log(obj);
    if (obj.trade.length > 0) {
        if (confirm("Deseja deletar as trocas selecionadas?")) {
            $.ajax({
                url: "Remove",
                method: "POST",
                dataType: "JSON",
                contentType: "application/json",
                data: JSON.stringify(obj),
                success: function (data) {
                    if (data.deleted) {
                        window.location.href = data.url;
                    }
                }, error: function () {
                    alert("Ocorreu um erro ao tentar deletar as trocas.");
                    window.location.reload = true;
                }
            });
        }
    }
});

/*HISTORICO*/

$(document).on("click", ".increase-historic", function (e) {

    increaseDecreaseHistoric(".decrease-increase-value", true)

    e.preventDefault();
});


$(document).on("click", ".decrease-historic", function (e) {

    increaseDecreaseHistoric(".decrease-increase-value", false)

    e.preventDefault();
})


function increaseDecreaseHistoric(class_button, increase) {
    var value = $(class_button).val();

    if (!increase) value = parseInt(value) - 1;
    else value = parseInt(value) + 1;

    if (!increase && value >= 0 || increase) {

        $.ajax({
            url: "GetHistoric",
            method: "GET",
            dataType: "JSON",
            contentType: "application/json",
            data: {
                value,
                increment: increase
            },
            success: function (data) {
                if (data.has > 0) {

                    var historic_field = $(".historic-container").html("");
                    var historic_items = data.temp;

                    $(historic_items).each(function (index, item) {

                        var date = new Date(parseInt(item.Data.substr(6)));
                        var month = (date.getMonth() + 1),
                            day = date.getDate(),
                            year = date.getFullYear();

                        switch (month) {
                            case 1:
                                month = "JAN";
                                break;
                            case 2:
                                month = "FEV";
                                break;
                            case 3:
                                month = "MAR";
                                break;
                            case 4:
                                month = "ABR";
                                break;
                            case 5:
                                month = "MAI";
                                break;
                            case 6:
                                month = "JUN";
                                break;
                            case 7:
                                month = "JUL";
                                break;
                            case 8:
                                month = "AGO";
                                break;
                            case 9:
                                month = "SET";
                                break;
                            case 10:
                                month = "OUT";
                                break;
                            case 11:
                                month = "NOV";
                                break;
                            case 12:
                                month = "DEZ";
                                break;
                        }

                        var toAppend = "<div class='historic-item'>" +
                            "<div class='date-historic-item'>" +
                            "<div>" +
                            "<label class='year-date-historic'>" + day + " " + month + "</label>" +
                            "<label class='year-date-historic'>" + year + "</label>" +
                            "</div>" +
                            "</div>" +
                            "<div class='text-historic-item'>" +
                            "<span>" +
                            item.Descricao +
                            "</span>" +
                            "</div>" +
                            "</div>";

                        historic_field.append(toAppend);
                    });

                    historic_field.append("<input type='hidden' value='" + (value) + "' class='decrease-increase-value'/>");
                    historic_field.append("<button class='decrease-historic btn-trades'><</button> ");
                    historic_field.append("<button class='increase-historic btn-trades'>></button>");
                }
            }, error: function () {
                alert("Ocorreu um erro ao atualizar a linha do tempo.");
                window.location.reload = true;
            }
        })
    }
}

/*TROCAS INCREMENTAR E DECREMENTAR*/


$(document).on("click", ".increase-trades", function (e) {

    increaseDecreaseTrades(".decrease-increase-value-trades", true)

    e.preventDefault();
});


$(document).on("click", ".decrease-trades", function (e) {

    increaseDecreaseTrades(".decrease-increase-value-trades", false)

    e.preventDefault();
})


function increaseDecreaseTrades(class_button, increase) {
    var value = $(class_button).val();

    if (!increase) value = parseInt(value) - 1;
    else value = parseInt(value) + 1;

    if (!increase && value >= 0 || increase) {

        $.ajax({
            url: "GetTrades",
            method: "GET",
            dataType: "JSON",
            contentType: "application/json",
            data: {
                value,
                increment: increase
            },
            success: function (data) {
                console.log(data);
                if (data.has) {

                    $(".table-trades").remove();

                    var leader = $(".width-max-table");
                    var toAppend = "<table class='table-trades' width=200 cellpadding=10>" +
                        "<thead>" +
                        "<tr>" +
                        "<th scope='col' style='width:3%'> </th>" +
                        "<th scope='col' style='width:13.857142%'>Tipo</th>" +
                        "<th scope='col' style='width:13.857142%;text-align:right;'>Comprar</th>" +
                        "<th scope='col' style='width:13.857142%'>Moeda</th>" +
                        "<th scope='col' style='width:13.857142%;text-align:right;'>Vender</th>" +
                        "<th scope='col' style='width:13.857142%'>Moeda</th>" +
                        "<th scope='col' style='width:13.857142%'>Troca</th>" +
                        "<th scope='col' style='width:13.857142%'>Date</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody></tbody>" +
                        "</table>";

                    $(toAppend).insertBefore(".width-max-table .container-buttons");
                    
                    $(data.temp).each(function (index, item) {

                        var tipo = "";

                        var date = new Date(parseInt(item.DataTroca.substr(6)));
                        var splited = ISODateString(date).toString().substr(0,10).split('-');                        

                        var month = splited[1],
                            year = splited[0],
                            day = splited[2];

                        switch (item.Tipo) {
                            case "Entrada":
                                tipo = "green-text";
                                break;
                            case "Saída":
                                tipo = "red-text";
                                break;
                            case "Troca":
                                break;
                        }

                        toAppend = "<tr class='tr-trade-row' data-id='"+item.Id+"'>"+
                            "<th scope='row'>"+
                                "<input type='checkbox' class='ckb-selected-row'/>"+
                            "</th>"+
                            "<td class='"+tipo+"'>"+item.Tipo+"</td>"+
                            "<td style='text-align:right'>"+item.ValorCompra+"</td>"+
                            "<td>" + item.MoedaCompra +"</td>"+
                            "<td style='text-align:right'>" + item.ValorVenda +"</td>"+
                            "<td>"+item.MoedaVenda+"</td>"+
                            "<td>Bitstamp CSV</td>"+
                            "<td>" + `${day}/${month}/${year}`+"</td>"+
                        "</tr>"+
                        "<tr class='tr-info-row' data-id='"+item.Id+"'>"+
                            "<td class='td-info-row' colspan=8>"+
                                "<div class='container-info disabled'>"+
                                    "<div class='line-item'>"+
                                        "<label>Compra: "+item.ValorCompra+" " + item.MoedaCompra+"</label>"+
                                    "</div>"+
                                    "<div class='line-item'>"+
                                        "<label>Venda:"+item.ValorVenda + " " + item.MoedaVenda+"</label>"+
                                    "</div>"+
                                    "<div class='line-item'>"+
                                        "<label>Taxa:"+item.ValorTaxa + " " + item.MoedaTaxa+"</label>"+
                                    "</div>"+
                                    "<div class='line-item'>"+
                                        "<label>"+item.Tipo+" realizada em: "+ `${day}/${month}/${year}` +"</label>"+
                                    "</div>"+
                                    "<div class='line-item'>"+
                                        "<label>Comentário:"+item.Comentario+"</label>"+
                                    "</div>"+
                                    "<div class='line-item last-line-item'>"+
                                        "<label>ID da Troca: "+item.Id+"</label>"+
                                    "</div>"+
                                "</div>"+
                            "</td>"+
                            "</tr>";

                        leader.find("table tbody").append(toAppend);                        
                    });
                    $(class_button).val(value);
                }
                else {
                    //alert("Não tem");
                }
            }, error: function () {
                alert("Ocorreu um erro ao atualizar a linha do tempo.");
                window.location.reload = true;
            }
        })
    }
}

function ISODateString(d) {
    function pad(n) { return n < 10 ? '0' + n : n }
    return d.getUTCFullYear() + '-'
        + pad(d.getUTCMonth() + 1) + '-'
        + pad(d.getUTCDate()) + 'T'
        + pad(d.getUTCHours()) + ':'
        + pad(d.getUTCMinutes()) + ':'
        + pad(d.getUTCSeconds()) + 'Z'
}