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
        { y: data['pendentes'][4]['Ano'], f: data['pendentes'][4]['DebitoFornecedores']*-1, c: data['pendentes'][4]['DebitoClientes'] }
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
    $('#pencent-divida').empty();
    $('#graph_title').empty();
    $('table#pendentes tbody').empty();
    $('#graph_title').append('<button style="background: transparent;border: none;font-size: 12px;color:#428bca;"></button>');
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

   var debitosPendentes = {clientes:0, fornecedores:0};

for(var a=0; a < pendentes['trimestres'].length; a++)
   for(var i = 0; i < pendentes['trimestres'][a]['pendentesMensais'].length; i++){
    for(var j = 0; j < pendentes['trimestres'][a]['pendentesMensais'][i]['pendentesClientes'].length; j++)
        debitosPendentes['clientes'] += (pendentes['trimestres'][a]['pendentesMensais'][i]['pendentesClientes'][j]['TotalMerc']+pendentes['trimestres'][a]['pendentesMensais'][i]['pendentesClientes'][j]['TotalIVA']);

    for(var j = 0; j < pendentes['trimestres'][a]['pendentesMensais'][i]['pendentesFornecedores'].length;j++)
        debitosPendentes['fornecedores'] += (pendentes['trimestres'][a]['pendentesMensais'][i]['pendentesFornecedores'][j]['TotalMerc']+pendentes['trimestres'][a]['pendentesMensais'][i]['pendentesFornecedores'][j]['TotalIVA']);
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

    Morris.Donut({
        element: 'pencent-divida',
        data: [
        {label: 'Fornecedores\n(a Pagar)', value: (debitosPendentes['fornecedores']*-1)/(debitosPendentes['clientes']+debitosPendentes['fornecedores']*-1)},
        {label: 'Clientes\n(a Receber)', value: debitosPendentes['clientes']/(debitosPendentes['clientes']+(debitosPendentes['fornecedores'])*-1) }
        ],
        formatter: function (y) { 
            return (y*100).toFixed(2)+'%';
        },
        resize: true
    });

    function showMeses(){
        var trimestreNum = 0;
        if($(this).text() == '1º Trimestre')
            trimestreNum = 0;
        else
            if($(this).text() == '2º Trimestre')
                trimestreNum = 1;
            else
                if($(this).text() == '3º Trimestre')
                    trimestreNum = 2;
                else
                    if($(this).text() == '4º Trimestre')
                        trimestreNum = 3;

                    pendentesMensais(ano,trimestreNum,data,{debitoAcumulado:false});
                    return;
                }

                function displayTable(){
                    var bar_id = $(this).index()-16;
                    var options = {trimestre:'',tipo:'', entidadeLink:''};

                    $('table#pendentes thead').empty();
                    $('table#pendentes tbody').empty();

                    if(bar_id < 2)
                        options['trimestre'] = 0;
                    else
                        if(bar_id < 4)
                            options['trimestre'] = 1;
                        else
                            if(bar_id < 6)
                                options['trimestre'] = 2;
                            else
                                if(bar_id < 8)
                                    options['trimestre'] = 3;

                                if(bar_id%2 == 1){
                                    options['tipo'] = 'pendentesClientes';
                                    options['entidadeLink'] = 'ClientesShow';
                                }
                                else
                                    options['tipo'] = 'pendentesFornecedores';

                                var listaPendentesMensais = pendentes['trimestres'][options['trimestre']]['pendentesMensais'];

                                $('table#pendentes thead').append('<tr><th rowspan="2">Tipo Documento</th><th rowspan="2">Entidade</th><th colspan="2">Carga</th><th colspan="2">Descarga</th><th colspan="2">Pagamento</th><th rowspan="2">Data Vencimento</th><th colspan="3">Total</th></tr><tr><th>Local</th><th>Hora</th><th>Local</th><th>Hora</th><th>Condição</th><th>Modo</th><th>IVA</th><th>Mercadoria</th><th>Final</th></tr>');
                                for(var itr_mes = 0; itr_mes < listaPendentesMensais.length; itr_mes++){
                                    var pendentes_mes = listaPendentesMensais[itr_mes][options['tipo']];
                                    for(var i = 0; i < pendentes_mes.length; i++){
                                        $('table#pendentes tbody').append('<tr><td>'+pendentes_mes[i]['TipoDoc']+'</td><td><a onclick="'+options['entidadeLink']+'(\''+pendentes_mes[i]["Entidade"]+'\')" style="cursor: pointer;">'
                                            +pendentes_mes[i]['Entidade']+'</a></td><td>'
                                            +pendentes_mes[i]['LocalCarga']+'</td><td style="text-align: center;">'
                                            +pendentes_mes[i]['HoraCarga']+'</td><td>'
                                            +pendentes_mes[i]['LocalDescarga']+'</td><td style="text-align: center;">'
                                            +pendentes_mes[i]['HoraDescarga']+'</td><td>'
                                            +pendentes_mes[i]['CondPag']+'</td><td>'
                                            +pendentes_mes[i]['ModoPag']+'</td><td style="text-align: center;">'
                                            +/\d{4}-\d{2}-\d{2}/.exec(pendentes_mes[i]['DataVencimento'])+'</td><td style="text-align:right;">'
                                            +pendentes_mes[i]['TotalIVA']+' €</td><td style="text-align:right;">'
                                            +pendentes_mes[i]['TotalMerc']+' €</td><td style="text-align:right;font-weight: bold;">'
                                            +(pendentes_mes[i]['TotalMerc']+pendentes_mes[i]['TotalIVA'])+' €</td></tr>');
}
}
}

$('rect').on('click',displayTable);
$('tspan').on('click',showMeses);
$('rect').css('cursor','pointer');
}

function pendentesMensais(ano, trimestre, data, options){

    $('#graph').empty();
    $('#pencent-divida').empty();
    $('#graph_title').empty();
    $('table#pendentes tbody').empty();
    $('#graph_title').append('<button style="background: transparent;border: none;font-size: 12px;color:#428bca;"></button>');
    $('#graph_title').append('Referente ao ano <a id="return" style="cursor:pointer;">'+ano+'</a> - '+(trimestre+1)+'º Trimestre');

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
       pendentesMensais(ano, trimestre, data, {debitoAcumulado:acumulativeMode['bool']});
   }

   $('#graph_title button').on('click', changeAculativeMode);


   for(var i=0; i < data['pendentes'].length; i++)
    if(data['pendentes'][i]['Ano'] == ano){
        pendentes = data['pendentes'][i]['trimestres'][trimestre];
    }

    var debitosPendentes = {clientes:0, fornecedores:0};

    for(var i = 0; i < pendentes['pendentesMensais'].length; i++){
        for(var j = 0; j < pendentes['pendentesMensais'][i]['pendentesClientes'].length; j++)
            debitosPendentes['clientes'] += (pendentes['pendentesMensais'][i]['pendentesClientes'][j]['TotalMerc']+pendentes['pendentesMensais'][i]['pendentesClientes'][j]['TotalIVA']);

        for(var j = 0; j < pendentes['pendentesMensais'][i]['pendentesFornecedores'].length;j++)
            debitosPendentes['fornecedores'] += (pendentes['pendentesMensais'][i]['pendentesFornecedores'][j]['TotalMerc']+pendentes['pendentesMensais'][i]['pendentesFornecedores'][j]['TotalIVA']);
    }

    console.log(pendentes['pendentesMensais'][2]['DebitoFornecedores'+acumulativeMode['append']]*-1);

    // Use Morris.Bar
    Morris.Bar({
        element: 'graph',
        data: [
        { y: convertMesIdToString(pendentes['pendentesMensais'][0]['Mes']), f: pendentes['pendentesMensais'][0]['DebitoFornecedores'+acumulativeMode['append']]*-1, c: pendentes['pendentesMensais'][0]['DebitoClientes'+acumulativeMode['append']]+' €' },
        { y: convertMesIdToString(pendentes['pendentesMensais'][1]['Mes']), f: pendentes['pendentesMensais'][1]['DebitoFornecedores'+acumulativeMode['append']]*-1, c: pendentes['pendentesMensais'][1]['DebitoClientes'+acumulativeMode['append']] },
        { y: convertMesIdToString(pendentes['pendentesMensais'][2]['Mes']), f: pendentes['pendentesMensais'][2]['DebitoFornecedores'+acumulativeMode['append']]*-1, c: pendentes['pendentesMensais'][2]['DebitoClientes'+acumulativeMode['append']] }
        ],
        xkey: 'y',
        ykeys: ['f', 'c'],
        labels: ['Fornecedores', 'Clientes']
    });

    Morris.Donut({
        element: 'pencent-divida',
        data: [
        {label: 'Fornecedores\n(a Pagar)', value: (debitosPendentes['fornecedores']*-1)/(debitosPendentes['clientes']+debitosPendentes['fornecedores']*-1)},
        {label: 'Clientes\n(a Receber)', value: debitosPendentes['clientes']/(debitosPendentes['clientes']+(debitosPendentes['fornecedores'])*-1) }
        ],
        formatter: function (y) { 
            return (y*100).toFixed(2)+'%';
        },
        resize: true
    });

    function displayTable(){

        var bar_id = $(this).index()-15;
        var options = {mes:'',tipo:'', entidadeLink:''};

        $('table#pendentes thead').empty();
        $('table#pendentes tbody').empty();

        if(bar_id < 2)
            options['mes'] = 0;
        else
            if(bar_id < 4)
                options['mes'] = 1;
            else
                if(bar_id < 6)
                    options['mes'] = 2;

                if(bar_id%2 == 1){
                    options['tipo'] = 'pendentesClientes';
                    options['entidadeLink'] = 'ClientesShow';
                }
                else
                    options['tipo'] = 'pendentesFornecedores';

                var listaPendentes = pendentes['pendentesMensais'][options['mes']][options['tipo']];

                $('table#pendentes thead').append('<tr><th rowspan="2">Tipo Documento</th><th rowspan="2">Entidade</th><th colspan="2">Carga</th><th colspan="2">Descarga</th><th colspan="2">Pagamento</th><th rowspan="2">Data Vencimento</th><th colspan="3">Total</th></tr><tr><th>Local</th><th>Hora</th><th>Local</th><th>Hora</th><th>Condição</th><th>Modo</th><th>IVA</th><th>Mercadoria</th><th>Final</th></tr>');

                for(var i = 0; i < listaPendentes.length; i++){
                    $('table#pendentes tbody').append('<tr><td>'+listaPendentes[i]['TipoDoc']+'</td><td><a onclick="'+options['entidadeLink']+'(\''+listaPendentes[i]["Entidade"]+'\')" style="cursor: pointer;">'
                        +listaPendentes[i]['Entidade']+'</a></td><td>'
                        +listaPendentes[i]['LocalCarga']+'</td><td style="text-align: center;">'
                        +listaPendentes[i]['HoraCarga']+'</td><td>'
                        +listaPendentes[i]['LocalDescarga']+'</td><td style="text-align: center;">'
                        +listaPendentes[i]['HoraDescarga']+'</td><td>'
                        +listaPendentes[i]['CondPag']+'</td><td>'
                        +listaPendentes[i]['ModoPag']+'</td><td style="text-align: center;">'
                        +/\d{4}-\d{2}-\d{2}/.exec(listaPendentes[i]['DataVencimento'])+'</td><td style="text-align:right;">'
                        +listaPendentes[i]['TotalIVA']+' €</td><td style="text-align:right;">'
                        +listaPendentes[i]['TotalMerc']+' €</td><td style="text-align:right;font-weight: bold;">'
                        +(listaPendentes[i]['TotalMerc']+listaPendentes[i]['TotalIVA'])+' €</td></tr>');
}
}
function backToAno(){
    pendentesTrimestrais(ano,data,options);
}
$('rect').on('click',displayTable);
$('#return').on('click', backToAno);
$('rect').css('cursor','pointer');
}