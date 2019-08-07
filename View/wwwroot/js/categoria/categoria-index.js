$(function () {
    $idputs = -1;
    $tabelaCategoria = $("#categoria-index").DataTable({
        ajax: "https://localhost:5001/categoria/obtertodos?colunaOrdem=nome&ordem=DESC",
        serverSide: true,
        columns: [
            { data: 'id' },
            { data: 'nome' },
            {
                render: function (data, type, row) {
                    return '<button class="btn btn-primary mr-2 botao-editar"\
        data-id="'+ row.id + '">Editar</button>\
        <button class="btn btn-danger botao-apagar" data-id="' + row.id + '">Apagar</button'
                }
            }
        ]
    });

    $('#categoria-botao-salvar').on('click', function () {
        $nome = $('#categoria-campo-nome').val();
        if ($idputs == -1) {
            salvar($nome);
        } else {
            alterar($nome);
        }

    });

    function alterar($nome) {
        $.ajax({
            url: 'https://localhost:5001/categoria/alterar',
            method: 'post',
            dataType: 'json',
            data: {
                id: $idputs,
                nome: $nome
            },
            success: function (data) {
                $('#modal-categoria').modal('hide');
                $tabelaCategoria.ajax.reload();
                $idputs = -1;
                $('#categoria-campo-nome').val('');
            }
        })
    }
    function salvar($nome) {
        $nome = $('#categoria-campo-nome').val();
        alert($nome);

        $.ajax({
            url: 'https://localhost:5001/categoria/cadastrar',
            method: 'post',
            dataType: 'json',
            data: {
                'nome': $nome
            },
            success: function (data) {
                $('#modal-categoria').modal('hide');
                $tabelaCategoria.ajax.reload();
            },
            error: function (error) {
                alert('deu ruim ;c')
            }

        })
    }

    $('.table').on('click', '.botao-apagar', function () {
        $id = $(this).data('id');
        $.ajax({
            url: 'https://localhost:5001/categoria/apagar?id=' + $id,
            method: 'get',
            success: function (data) {
                $tabelaCategoria.ajax.reload();
            },
            error: function (error) {
                alert('Não deu boa :c');
            }
        })
    })

    $('.table').on('click', '.botao-editar', function () {
        $idputs = $(this).data('id');
        $.ajax({
            url: 'https://localhost:5001/categoria/obterpeloid?id=' + $idputs,
            method: 'get',
            success: function (data) {
                $('#categoria-campo-nome').val(data.nome);
                $('#modal-categoria').modal('show');
            },
            error: function (error) {
                alert("Não foi possível carregar o modal.")
            }
        });


    });

});