function DocumentosIndex(cliente){

    $('#documentos_tab').empty();
    $('#documentos_tab').load('../documentos/index.html');

    var _url = 'http://localhost:49822/api/Documentos';

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){ 
        $('table#documentos thead').append('<tr><th rowspan="2">Tipo Documento</th><th colspan="2">Carga</th><th colspan="2">Descarga</th><th colspan="2">Pagamento</th><th rowspan="2">Data Vencimento</th><th colspan="2">Total</th></tr><tr><th>Local</th><th>Hora</th><th>Local</th><th>Hora</th><th>Condição</th><th>Modo</th><th>IVA</th><th>Mercadoria</th></tr>');
        for(var i = 0; i < data.length; i++){
            if(cliente == data[i]["Entidade"])
                $('table#documentos tbody').append('<tr><td>'+data[i]['TipoDoc']+'</td><td>'
                    +data[i]['LocalCarga']+'</td><td>'
                    +data[i]['HoraCarga']+'</td><td>'
                    +data[i]['LocalDescarga']+'</td><td>'
                    +data[i]['HoraDescarga']+'</td><td>'
                    +data[i]['CondPag']+'</td><td>'
                    +data[i]['ModoPag']+'</td><td>'
                    +data[i]['DataVencimento']+'</td><td>'
                    +data[i]['TotalIVA']+'</td><td>'
                    +data[i]['TotalMerc']+'</td></tr>');
        }
    });
}

function DocumentosShow(numDoc){
}