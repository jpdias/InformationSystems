function ArtigosIndex(){

    loadPage('../artigos/index.html');

    var _url = 'http://localhost:49822/api/Artigos';

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){  
   
        $('table#artigos thead').append('<tr><th>Artigo</th><th>Descricao</th><th>Unidade Venda</th><th>Iva</th><th>Stock Actual</th></tr>');
        for(var i = 0; data.length; i++){
            $('table#artigos tbody').append('<tr><td><a onclick="ArtigosShow(\''+data[i]["cod"]+'\')" style="cursor: pointer;">'+data[i]["cod"]+'</a></td><td>'
                +data[i]['Descricao']+'</td><td>'
                +data[i]['UnidadeVenda']+'</td><td>'
                +data[i]['IVA']+'</td><td>'
                +data[i]['STKActual']+'</td></tr>');
        }
    }); 
}
function ArtigosShow(cod){

    loadPage('../artigos/show.html');

    var _url = 'http://localhost:49822/api/Artigos/'+cod;

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){ 

    $('table#artigo thead').append('<tr><th>Artigo</th><th>Descricao</th><th>Tipo</th><th>Familia</th><th>Código Barras</th><th>Unidade Venda</th><th>Iva</th><th>Stock Actual</th></tr>');
    $('table#artigo tbody').append('<tr><td>'+data['cod']+'</td><td>'
                +data['Descricao']+'</td><td>'
                +data['TipoArtigo']+'</td><td>'
                +data['Familia']+'</td><td>'
                +data['CodBarras']+'</td><td>'
                +data['UnidadeVenda']+'</td><td>'
                +data['IVA']+'</td><td>'
                +data['STKActual']+'</td></tr>'); 
    $('.page-header.artigo').append(data['Descricao']);
    });
}