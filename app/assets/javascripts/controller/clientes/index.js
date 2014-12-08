function ClientesIndex(){

    loadPage('../clientes/index.html');

    var _url = 'http://localhost:49822/api/Clientes';

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){  
   
        $('table#clientes thead').append('<tr><th>Cliente</th><th>Nome</th><th>Nome Fiscal</th><th>Nº Contribuinte</th><th>Pais</th><th>Debito Total</th></tr>');
        for(var i = 0; data.length; i++){
            $('table#clientes tbody').append('<tr><td><a onclick="ClientesShow(\''+data[i]["cod"]+'\')" style="cursor: pointer;">'+data[i]["cod"]+'</a></td><td>'
                +data[i]['Nome']+'</td><td>'
                +data[i]['NomeFiscal']+'</td><td>'
                +data[i]['NumContrib']+'</td><td>'
                +data[i]['Pais']+'</td><td>'
                +data[i]['TotalDeb']+'</td></tr>');
        }
    }); 
    $('.page-header.clientes').append('Clientes');
    
}
function ClientesShow(cod){

    loadPage('../clientes/show.html');

    var _url = 'http://localhost:49822/api/Clientes/'+cod;

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){ 

    $('table#cliente thead').append('<tr><th>Cliente</th><th>Nome</th><th>Nome Fiscal</th><th>Nº Contribuinte</th><th>Pais</th><th>Morada</th><th>Localidade</th><th>Codigo-Postal</th><th>Distrito</th><th>Telemovel</th><th>Fax</th><th>Pagamento</th><th>Moeda</th><th>Debito Total</th></tr>');
    $('table#cliente tbody').append('<tr><td>'+data['cod']
        +'</td><td>'+data['Nome']
        +'</td><td>'+data['NomeFiscal']
        +'</td><td>'+data['NumContrib']
        +'</td><td>'+data['Pais']
        +'</td><td>'+data['Fac_Mor']
        +'</td><td>'+data['Fac_Local']
        +'</td><td>'+data['Fac_Cp']
        +'</td><td>'+data['Fac_Cploc']
        +'</td><td>'+data['Fac_Tel']
        +'</td><td>'+data['Fac_Fax']
        +'</td><td>'+data['ModoPag']
        +'</td><td>'+data['Moeda']
        +'</td><td>'+data['TotalDeb']
        +'</td></tr>'); 
    $('.page-header.cliente').append(data['NomeFiscal']);
    $('.data_criacao').append(data['DataCriacao']);

    });
}