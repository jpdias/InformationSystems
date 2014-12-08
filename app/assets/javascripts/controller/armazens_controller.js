function ArmazensIndex(){

    loadPage('../armazens/index.html');

    var _url = 'http://localhost:49822/api/Armazens';

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){  
   
        $('table#armazens thead').append('<tr><th>Armazem</th><th>Descricao</th><th>Morada</th><th>Distrito</th><th>Pais</th></tr>');
        for(var i = 0; data.length; i++){
            $('table#armazens tbody').append('<tr><td><a onclick="ArmazensShow(\''+data[i]["cod"]+'\')" style="cursor: pointer;">'+data[i]["cod"]+'</a></td><td>'
                +data[i]['Descricao']+'</td><td>'
                +data[i]['Morada']+'</td><td>'
                +data[i]['Distrito']+'</td><td>'
                +data[i]['Pais']+'</td></tr>');
        }
    }); 
}
function ArmazensShow(cod){

    loadPage('../armazens/show.html');

    var _url = 'http://localhost:49822/api/Armazens/'+cod;

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){ 

    $('table#armazem thead').append('<tr><th>Armazem</th><th>Descricao</th><th>Morada</th><th>Morada2</th><th>Localidade</th><th>Codigo-Postal</th><th>Distrito</th><th>Pais</th><th>Telefone</th><th>Fax</th></tr>');
    $('table#armazem tbody').append('<tr><td>'+data['cod']+'</td><td>'
                +data['Descricao']+'</td><td>'
                +data['Morada']+'</td><td>'
                +data['Morada2']+'</td><td>'
                +data['Localidade']+'</td><td>'
                +data['Cp']+'-'+data['CpLocalidade']+'</td><td>'
                +data['Distrito']+'</td><td>'
                +data['Pais']+'</td><td>'
                +data['Telefone']+'</td><td>'
                +data['Fax']+'</td></tr>'); 
    $('.page-header.armazem').append(data['Descricao']);
    });
}