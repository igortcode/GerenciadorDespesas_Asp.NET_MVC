function CarregarDadosGastosTotais() {
    $.ajax({
        url: 'Despesas/GastosTotais',
        method: 'POST',
        success: function (dados) {
            new Chart(document.getElementById("GraficoGastosTotais"), {
                type: 'line',
                data: {
                    labels: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],

                    datasets: [{
                        label: "Total gasto",
                        data: dados,
                        backgroundColor: "#ecf0f1",
                        borderColor: "#2980b9",
                        fill: false,
                        spanGaps: false
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: "Total gasto"
                    }
                }
            });
        }
    });
}