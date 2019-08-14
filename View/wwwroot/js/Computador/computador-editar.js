$(function () {
    $idComputador = $("#computador-id").val();

    $("#computador-editar-categoria").select2({
        ajax: {
            url: "/categoria/obtertodosselect2", 
            dataType: "json"
        }
    })


    $("#computador-editar-salvar").on("click", function () {
        $nome = $("#computador-editar-nome").val();
        $preco = $("#computador-editar-preco").val();
        $categoria = $("#computador-editar-categoria").val();
        $.ajax({
            url: "/computador/alterar",
            method: "post",
            data: {
                id: $idComputador,
                nome: $nome,
                preco: $preco,
                idcategoria: $categoria
            },
            success: function (data) {
                alert("Alterado");
            },
            error: function (data) {
                alert("Não foi possível alterar");
            }
        })
    })
})