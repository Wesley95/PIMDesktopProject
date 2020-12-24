var global_words = {
    words: []
};

$(document).on("click", ".tab-item-button", function () {
    const id = $(this).attr("id");
    const leader = $(this).parents(".tab");

    leader.find(".tab-item-button").removeClass("active");
    $(this).addClass("active");

    leader.find(".container-config-tab").css("display", "none");
    leader.find(".container-config-tab#" + id).css("display", "flex");
});

function GetWords() {
    return Promise.resolve($.ajax({
        url: "GetWords",
        method: "GET",
        dataType: "JSON",
        contentType: "application/json"
    }));
}

function shuffleArray(arraypass) {
    var array = arraypass;
    for (var i = array.length - 1; i > 0; i--) {
        var j = Math.floor(Math.random() * (i + 1));
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    return array;
}

$(document).on("click", ".mix-words", function (e) {
    //console.log(global_words);
    $(this).prop("disabled", true);
    GetWords().then(function (data) {

        var words = shuffleArray(data);

        var word_place = $(".word-place ul").html("");
        global_words.words = [];
        console.log(words);
        for (var l = 0; l < 14; l++) {
            word_place.append(`<li>${words[l].Word}</li>`);
            global_words.words.push(`${words[l].Word}`);
        }
    });

    e.preventDefault();
    $(this).prop("disabled", false);
});

$(document).on("click", ".container-config-item .generate-phrase", function () {
    var $this = $(".container-config-item");

    var toAppend = "<div class='word-place'>" +
        "<ul>" +
        "</ul>" +
        "</div>" +
        "<div class='confirm-phrase'>" +
        "<button class='btn-trades mix-words'>Misturar</button>" +
        "<div class='btn-input'>" +
        "<input type='text' class='spcltr cleanchar inp-confirm-phrase'/>" +
        "<button class='btn-confirm-phrase config-button'>Confirmar</button>" +
        "</div>" +
        "</div>";

    $this.html("").append(toAppend);
});

$(document).on("click", ".btn-confirm-phrase", function (e) {

    var temp_word = "";
    for (var l = 0; l < global_words.words.length; l++) {
        temp_word += `${global_words.words[l]};`;
    }
    temp_word = temp_word.slice(0, -1);

    var words = $(".inp-confirm-phrase").val().replaceAll(' ', ';');

    words = words[words.length - 1] === ';' ? words.slice(0, -1) : words;
    //console.log(global_words);
    //console.log(`${words.toUpperCase()}\n${temp_word.toUpperCase()}`);

    if (words.toUpperCase() === temp_word.toUpperCase()) {
        $.ajax({
            url: "UpdateOrInsert",
            method: "POST",
            data: { words: global_words.words },
            success: function (data) {
                alert("A frase secreta foi atualizada com sucesso. A página será atualizada para carregar as informações novamente.");
                location.reload();
            }, error: function () {
                alert("Ocorreu um erro ao tentar atualizar a frase secreta.");
                location.reload();
            }
        });
    }

    e.preventDefault();
});

function GetSome(url) {
    return Promise.resolve($.ajax({
        url: url,
        method: "GET",
        dataType: "JSON",
        contentType: "application/json"
    }))
}


$(document).on("click", ".confirm-pass-change", function (e) {

    GetSome("GetCurPass").then(function (data) {

        var cur_pass = $("#cur-pass").val();
        var word = $("#phrase-field").val().replaceAll(' ', ';');
        word = word[word.length - 1] === ";" ? word.slice(0, -1) : word;

        if (cur_pass.length) {
            if (cur_pass === data.Senha) {
                GetSome("GetPhrase").then(function (phrase) {
                    if (word.length > 0) {
                        if (phrase.Frase === word) {
                            var pass = $("#new-pass").val(),
                                confirm_pass = $("#confirm-pass").val();

                            if (pass.length == 10) {
                                if (pass === confirm_pass) {
                                    //alert("Update");
                                    $.ajax({
                                        url: "UpdatePassword",
                                        method: "POST",
                                        data: { pass: pass },
                                        success: function (data) {
                                            if (data) {
                                                alert("Senha alterada com sucesso.");
                                                location.reload();
                                            }
                                        }, error: function () {
                                            alert("3Ocorreu um erro ao alterar a senha.");    
                                        }

                                    })
                                }
                                else {
                                    alert("A senha confirmada deve ser igual a nova senha.");
                                }
                            } else {
                                alert("A senha deve conter 10 caractéres.");
                            }
                            
                        }
                        else {
                            alert("A frase está incorreta.");
                        }
                    }
                    else {
                        alert("A frase deve ser confirmada para prosseguir.")
                    }
                }).catch(function () {
                    alert("Ocorreu um erro ao tentar alterar a senha.");
                    location.reload();
                });
            }
            else {
                alert("A senha atual deve ser confirmada para prosseguir.");
            }
        }
        else {
            alert("A senha atual deve ser confirmada para que possa prosseguir com a alteração da mesma.")
        }
    }).catch(function () {
        alert("Ocorreu um erro ao tentar alterar a senha.");
        location.reload();
    });

    e.preventDefault();
});