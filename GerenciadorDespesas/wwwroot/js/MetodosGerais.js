function PegarValores(dados) {
    var valores = [];
    var tamanho = dados.length;
    for (var i = 0; i < tamanho; i++) {
        valores.push(dados[i].valores);
    }
    return valores;
}

function PegarTiposDespesas(dados) {
    var labels = [];
    var tamanho = dados.length;
    for (var i = 0; i < tamanho; i++) {
        labels.push(dados[i].tiposDespesas);
    }
    return labels;
}

function PegarCores(quantidade) {
    var cores = [];

    while (quantidade > 0) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);
        cores.push("rgb(" + r + ", " + g + "," + b + ")");

        quantidade--;
    }
    return cores;
}