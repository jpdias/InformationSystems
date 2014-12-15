function AnaliseDebitoIndex(){

    loadPage('../analise_debito/index.html');

    var _url = 'http://localhost:49822/api/AnaliseDebito';

    $.ajax({
        url: _url,
        type: 'GET',
        contentType: "application/json;charset=UTF-8"

    }).done(function(data){  

        listarPendentes('anual',data);
    }); 
}

function listarPendentes(type, data){
    if(type == 'anual')'Ano'
        pendentesAnuais(data);
}

function pendentesAnuais(data){

    // Use Morris.Bar
    Morris.Bar({
        element: 'graph',
        data: [
        { y: data['pendentes'][0]['Ano'], f: data['pendentes'][0]['DebitoFornecedores']*-1, c: data['pendentes'][0]['DebitoClientes'] },
        { y: data['pendentes'][1]['Ano'], f: data['pendentes'][1]['DebitoFornecedores']*-1, c: data['pendentes'][1]['DebitoClientes'] },
        { y: data['pendentes'][2]['Ano'], f: data['pendentes'][2]['DebitoFornecedores']*-1, c: data['pendentes'][2]['DebitoClientes'] },
        { y: data['pendentes'][3]['Ano'], f: data['pendentes'][3]['DebitoFornecedores']*-1, c: data['pendentes'][3]['DebitoClientes'] },
        { y: data['pendentes'][4]['Ano'], f: data['pendentes'][4]['DebitoFornecedores']*-1, c: data['pendentes'][4]['DebitoClientes'] },
        { y: data['pendentes'][5]['Ano'], f: data['pendentes'][5]['DebitoFornecedores']*-1, c: data['pendentes'][5]['DebitoClientes'] },
        { y: data['pendentes'][6]['Ano'], f: data['pendentes'][6]['DebitoFornecedores']*-1, c: data['pendentes'][6]['DebitoClientes'] },
        { y: data['pendentes'][7]['Ano'], f: data['pendentes'][7]['DebitoFornecedores']*-1, c: data['pendentes'][7]['DebitoClientes'] }
        ],
        xkey: 'y',
        ykeys: ['f', 'c'],
        labels: ['Fornecedores', 'Clientes']
    });

    function showTrimestres(){
        pendentesTrimestrais($(this).text(),data,{debitoAcumulado:false});
    }
    $('tspan').on('click',showTrimestres);
}

function pendentesTrimestrais(ano, data, options){

    $('#graph').empty();
    $('#graph_title').empty();
    $('#graph_title').append('<button style="background: transparent;border: none;font-size: 12px;"></button>');
    $('#graph_title').append('Referente ao ano '+ano);

    var pendentes;
    var acumulativeMode = {append:'',bool:true};

    if(options['debitoAcumulado'] == true){
        acumulativeMode['append'] = 'Acumulado';
        acumulativeMode['bool'] = false;
        $('#graph_title button').text('Débito Acumulado');
    }
    else{
        acumulativeMode['append'] = '';
        acumulativeMode['bool'] = true;
        $('#graph_title button').text('Débito Não Acumulado');
    }

    function changeAculativeMode(){
       pendentesTrimestrais(ano, data, {debitoAcumulado:acumulativeMode['bool']});
    }

    $('#graph_title button').on('click', changeAculativeMode);


    for(var i=0; i < data['pendentes'].length; i++)
        if(data['pendentes'][i]['Ano'] == ano){
            pendentes = data['pendentes'][i];
        }
    // Use Morris.Bar
    Morris.Bar({
        element: 'graph',
        data: [
        { y: '1º Trimestre', f: pendentes['trimestres'][0]['DebitoFornecedores'+acumulativeMode['append']]*-1, c: pendentes['trimestres'][0]['DebitoClientes'+acumulativeMode['append']] },
        { y: '2º Trimestre', f: pendentes['trimestres'][1]['DebitoFornecedores'+acumulativeMode['append']]*-1, c: pendentes['trimestres'][1]['DebitoClientes'+acumulativeMode['append']] },
        { y: '3º Trimestre', f: pendentes['trimestres'][2]['DebitoFornecedores'+acumulativeMode['append']]*-1, c: pendentes['trimestres'][2]['DebitoClientes'+acumulativeMode['append']] },
        { y: '4º Trimestre', f: pendentes['trimestres'][3]['DebitoFornecedores'+acumulativeMode['append']]*-1, c: pendentes['trimestres'][3]['DebitoClientes'+acumulativeMode['append']] }
        ],
        xkey: 'y',
        ykeys: ['f', 'c'],
        labels: ['Fornecedores', 'Clientes']
    });


}