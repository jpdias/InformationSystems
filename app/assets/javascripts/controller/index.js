/*function getTable(table) {

    var _url = 'http://localhost:49822/api/'+table;
    var ret;
    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){        
        ret = data;
    });  

    return ret;
}

function getTableElement(table, id) {

    var _url = 'http://localhost:49822/api/'+table+'/'+id;

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){        
        show(table, data);
    });  
}

function index(Table, data){
    if(Table === "Clientes")
        ClientesIndex(data);
}

function show(Table, data){
    if(Table === "Clientes")
        ClientesShow(data);
}*/