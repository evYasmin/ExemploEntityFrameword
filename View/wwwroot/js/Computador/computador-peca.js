$(function () {
    $tabelaPecas = $("#computador-pecas-index").DataTable({
        ajax: "/computadorpeca/obtertodos?idComputador=" + $idComputador,
        serverSide: true,
        columns: [
            { data: "peca.Nome" },
            { data: "peca.Preco" },
            {
                render: function (data, type, row) {
                    return "\
<button class='btn btn-danger botao-apagar'\
data-id=" + row.id + ">Apagar</button>";
                }

            }
        ]
    })
});