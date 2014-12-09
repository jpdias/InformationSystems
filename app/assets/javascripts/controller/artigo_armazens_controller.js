function ArmazensIndex(){
}

function ArtigosArmazemShow(armazem){

    $('#stock').empty();
    $('#stock').load('../artigo_armazens/show.html');

    var _url = 'http://localhost:49822/api/ArtigoArmazens/'+armazem;

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){ 
        $('table#artigoarmazem thead').append('<tr><th>Artigo</th><th>StkActual</th><th>Qt. Reservada</th><th>Ultima Cont.</th><th>Data Ultima Cont.</th></tr>');
        for(var i = 0; data.length; i++){
            $('table#artigoarmazem tbody').append('<tr><td><a onclick="ArtigosShow(\''+data[i]["Artigo"]+'\')" style="cursor: pointer;">'+data[i]['Artigo']+'</td><td>'
                +data[i]['StkActual']+'</td><td>'
                +data[i]['QtReservada']+'</td><td>'
                +data[i]['UltimaContagem']+'</td><td>'
                +data[i]['DataUltimaContagem']+'</td></tr>');
        }
    });
}

function ArtigoArmazensShow(artigo){

    $('#stock').empty();
    $('#stock').load('../artigo_armazens/show.html');

    var _url = 'http://localhost:49822/api/ArtigoArmazens';

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){ 
        $('table#artigoarmazem thead').append('<tr><th>Armazem</th><th>StkActual</th><th>Qt. Reservada</th><th>Ultima Cont.</th><th>Data Ultima Cont.</th></tr>');
        for(var i = 0; data.length; i++){
            if(data[i]['Artigo'] == artigo)
            $('table#artigoarmazem tbody').append('<tr><td><a onclick="ArmazensShow(\''+data[i]["Armazem"]+'\')" style="cursor: pointer;">'+data[i]['Armazem']+'</td><td>'
                +data[i]['StkActual']+'</td><td>'
                +data[i]['QtReservada']+'</td><td>'
                +data[i]['UltimaContagem']+'</td><td>'
                +data[i]['DataUltimaContagem']+'</td></tr>');
        }
    });
}