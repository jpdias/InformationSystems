using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS800;
using Interop.StdPlatBS800;
using Interop.StdBE800;
using Interop.GcpBE800;
using ADODB;
using Interop.IGcpBS800;
//using Interop.StdBESql800;
//using Interop.StdBSSql800;C:\Users\user\Documents\Feup\4ano\SINF\Repositorio\InformationSystems\back_end\FirstREST\FirstREST\App_Start\

namespace FirstREST.Lib_Primavera
{
    public class Comercial
    {
        # region Cliente

        private static string _credential_comercial = "WINECORP";
        private static string _credential_user = "";
        private static string _credential_password = "";

        public static List<Model.Cliente> ListaClientes()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.Cliente cli = new Model.Cliente();
            List<Model.Cliente> listClientes = new List<Model.Cliente>();


            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT * FROM  CLIENTES");

                while (!objList.NoFim())
                {
                    cli = new Model.Cliente();
                    cli.cod         = objList.Valor("Cliente");
                    cli.Nome        = objList.Valor("Nome");
                    cli.Fac_Mor     = objList.Valor("Fac_Mor");
                    cli.Fac_Local   = objList.Valor("Fac_Local");
                    cli.Fac_Cp      = objList.Valor("Fac_Cp");
                    cli.Fac_Cploc   = objList.Valor("Fac_Cploc");
                    cli.Fac_Tel     = objList.Valor("Fac_Tel");
                    cli.Fac_Fax     = objList.Valor("Fac_Fax");
                    cli.TotalDeb    = objList.Valor("TotalDeb");
                    cli.NumContrib  = objList.Valor("NumContrib");
                    cli.Pais        = objList.Valor("Pais");
                    cli.ModoPag     = objList.Valor("ModoPag");
                    cli.Moeda       = objList.Valor("Moeda");
                    cli.DataCriacao = objList.Valor("DataCriacao");
                    cli.NomeFiscal  = objList.Valor("NomeFiscal");

                    listClientes.Add(cli);
                    objList.Seguinte();
                }

                return listClientes;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Cliente GetCliente(string cod)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objCli;


            Model.Cliente cli = new Model.Cliente();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

                if (PriEngine.Engine.Comercial.Clientes.Existe(cod) == true)
                {
                    objCli = PriEngine.Engine.Consulta("SELECT * FROM  CLIENTES WHERE Cliente = '"+cod+"'");
                    cli.cod = objCli.Valor("Cliente");
                    cli.Nome = objCli.Valor("Nome");
                    cli.Fac_Mor = objCli.Valor("Fac_Mor");
                    cli.Fac_Local = objCli.Valor("Fac_Local");
                    cli.Fac_Cp = objCli.Valor("Fac_Cp");
                    cli.Fac_Cploc = objCli.Valor("Fac_Cploc");
                    cli.Fac_Tel = objCli.Valor("Fac_Tel");
                    cli.Fac_Fax = objCli.Valor("Fac_Fax");
                    cli.TotalDeb = objCli.Valor("TotalDeb");
                    cli.NumContrib = objCli.Valor("NumContrib");
                    cli.Pais = objCli.Valor("Pais");
                    cli.ModoPag = objCli.Valor("ModoPag");
                    cli.Moeda = objCli.Valor("Moeda");
                    cli.DataCriacao = objCli.Valor("DataCriacao");
                    cli.NomeFiscal = objCli.Valor("NomeFiscal");
                    return cli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        #endregion Cliente;   // -----------------------------  END   CLIENTE    -----------------------

        # region Artigo

        public static Lib_Primavera.Model.Artigo GetArtigo(string cod)
        {
            StdBELista objList;
            Model.Artigo art = new Model.Artigo();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {
                if (PriEngine.Engine.Comercial.Artigos.Existe(cod) == true)
                {
                    objList = PriEngine.Engine.Consulta("SELECT * FROM  Artigo WHERE Artigo = '" + cod + "'");
                    art.cod = objList.Valor("Artigo");
                    art.Descricao = objList.Valor("Descricao");
                    art.CodBarras = objList.Valor("CodBarras");
                    art.UnidadeVenda = objList.Valor("UnidadeVenda");
                    art.IVA = objList.Valor("IVA");
                    art.Desconto = objList.Valor("Desconto");
                    art.Fornecedor = objList.Valor("Fornecedor");
                    art.STKActual = objList.Valor("STKActual");
                    art.Familia = objList.Valor("Familia");
                    art.TipoArtigo = objList.Valor("TipoArtigo");
                    return art;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public static List<Model.Artigo> ListaArtigos()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT * FROM  Artigo");

                while (!objList.NoFim())
                {
                    art = new Model.Artigo();
                    art.cod             = objList.Valor("Artigo");
                    art.Descricao       = objList.Valor("Descricao");
                    art.CodBarras       = objList.Valor("CodBarras");
                    art.UnidadeVenda    = objList.Valor("UnidadeVenda");
                    art.IVA             = objList.Valor("IVA");
                    art.Desconto        = objList.Valor("Desconto");
                    art.Fornecedor      = objList.Valor("Fornecedor");
                    art.STKActual       = objList.Valor("STKActual");
                    art.Familia         = objList.Valor("Familia");
                    art.TipoArtigo      = objList.Valor("TipoArtigo");

                    listArts.Add(art);
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }

        #endregion Artigo;

        # region Armazem

        public static Lib_Primavera.Model.Armazem GetArmazem(string cod)
        {
            StdBELista objList;
            Model.Armazem arm = new Model.Armazem();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {
                if (PriEngine.Engine.Comercial.Armazens.Existe(cod) == true)
                {
                    objList = PriEngine.Engine.Consulta("SELECT * FROM  Armazens WHERE Armazem = '" + cod + "'");
                    arm.cod = objList.Valor("Armazem");
                    arm.Descricao = objList.Valor("Descricao");
                    arm.Morada = objList.Valor("Morada");
                    arm.Localidade = objList.Valor("Localidade");
                    arm.Cp = objList.Valor("Cp");
                    arm.CpLocalidade = objList.Valor("CpLocalidade");
                    arm.Telefone = objList.Valor("Telefone");
                    arm.Fax = objList.Valor("Fax");
                    arm.Pais = objList.Valor("Pais");
                    arm.Morada2 = objList.Valor("Morada2");
                    arm.Distrito = objList.Valor("Distrito");
                    return arm;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public static List<Model.Armazem> ListaArmazens()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.Armazem arms = new Model.Armazem();
            List<Model.Armazem> listArms = new List<Model.Armazem>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT * FROM  Armazens");

                while (!objList.NoFim())
                {
                    arms = new Model.Armazem();
                    arms.cod = objList.Valor("Armazem");
                    arms.Descricao = objList.Valor("Descricao");
                    arms.Morada = objList.Valor("Morada");
                    arms.Localidade = objList.Valor("Localidade");
                    arms.Cp = objList.Valor("Cp");
                    arms.CpLocalidade = objList.Valor("CpLocalidade");
                    arms.Telefone = objList.Valor("Telefone");
                    arms.Fax = objList.Valor("Fax");
                    arms.Pais = objList.Valor("Pais");
                    arms.Morada2 = objList.Valor("Morada2");
                    arms.Distrito = objList.Valor("Distrito");

                    listArms.Add(arms);
                    objList.Seguinte();
                }

                return listArms;

            }
            else
            {
                return null;

            }

        }

        #endregion Armazem;

        # region ArtigoArmazem

        public static List<Model.ArtigoArmazem> GetArtigoArmazem(string armazem)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.ArtigoArmazem arms = new Model.ArtigoArmazem();
            List<Model.ArtigoArmazem> listArms = new List<Model.ArtigoArmazem>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT * FROM  ArtigoArmazem WHERE Armazem ='"+armazem+"'");

                while (!objList.NoFim())
                {
                    arms = new Model.ArtigoArmazem();
                    arms.Artigo = objList.Valor("Artigo");
                    arms.Armazem = objList.Valor("Armazem");
                    arms.StkActual = objList.Valor("StkActual");
                    arms.QtReservada = objList.Valor("QtReservada");
                    arms.UltimaContagem = objList.Valor("UltimaContagem");
                    arms.DataUltimaContagem = objList.Valor("DataUltimaContagem");

                    listArms.Add(arms);
                    objList.Seguinte();
                }

                return listArms;

            }
            else
            {
                return null;

            }
        }

        public static List<Model.ArtigoArmazem> ListaArtigoArmazens()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.ArtigoArmazem arms = new Model.ArtigoArmazem();
            List<Model.ArtigoArmazem> listArms = new List<Model.ArtigoArmazem>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT * FROM  ArtigoArmazem");

                while (!objList.NoFim())
                {
                    arms = new Model.ArtigoArmazem();
                    arms.Artigo = objList.Valor("Artigo");
                    arms.Armazem = objList.Valor("Armazem");
                    arms.StkActual = objList.Valor("StkActual");
                    arms.QtReservada = objList.Valor("QtReservada");
                    arms.UltimaContagem = objList.Valor("UltimaContagem");
                    arms.DataUltimaContagem = objList.Valor("DataUltimaContagem");

                    listArms.Add(arms);
                    objList.Seguinte();
                }

                return listArms;

            }
            else
            {
                return null;

            }

        }

        #endregion ArtigoArmazem;

        # region Documento

        public static List<Model.Documento> GetDocumento(string numDoc)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;
            StdBELista objListCondPag;

            Model.Documento arms = new Model.Documento();
            List<Model.Documento> listArms = new List<Model.Documento>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT * FROM  CabecDoc WHERE NumDoc ='" + numDoc + "'");

                while (!objList.NoFim())
                {
                    objListCondPag = PriEngine.Engine.Consulta("SELECT * FROM  CondPag WHERE CondPag ='" + objList.Valor("CondPag") + "'");

                    arms = new Model.Documento();
                    arms.Entidade = objList.Valor("Entidade");
                    arms.TipoDoc = objList.Valor("TipoDoc");
                    arms.NumDoc = objList.Valor("NumDoc");
                    arms.CondPag = objListCondPag.Valor("descricao");
                    arms.TotalMerc = objList.Valor("TotalMerc");
                    arms.TotalIVA = objList.Valor("TotalIVA");
                    arms.ModoPag = objList.Valor("ModoPag");
                    arms.DataVencimento = objList.Valor("DataVencimento");
                    arms.LocalCarga = objList.Valor("LocalCarga");
                    arms.HoraCarga = objList.Valor("HoraCarga");
                    arms.LocalDescarga = objList.Valor("LocalDescarga");
                    arms.HoraDescarga = objList.Valor("HoraDescarga");

                    listArms.Add(arms);
                    objList.Seguinte();
                }

                return listArms;

            }
            else
            {
                return null;

            }
        }

        public static List<Model.Documento> ListaDocumentos()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;
            StdBELista objListCondPag;

            Model.Documento arms = new Model.Documento();
            List<Model.Documento> listArms = new List<Model.Documento>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT * FROM  CabecDoc");

                while (!objList.NoFim())
                {
                    objListCondPag = PriEngine.Engine.Consulta("SELECT * FROM  CondPag WHERE CondPag ='" + objList.Valor("CondPag") + "'");

                    arms = new Model.Documento();
                    arms.Entidade = objList.Valor("Entidade");
                    arms.TipoDoc = objList.Valor("TipoDoc");
                    arms.NumDoc = objList.Valor("NumDoc");
                    arms.CondPag = objListCondPag.Valor("descricao");
                    arms.TotalMerc = objList.Valor("TotalMerc");
                    arms.TotalIVA = objList.Valor("TotalIVA");
                    arms.ModoPag = objList.Valor("ModoPag");
                    arms.DataVencimento = objList.Valor("DataVencimento");
                    arms.LocalCarga = objList.Valor("LocalCarga");
                    arms.HoraCarga = objList.Valor("HoraCarga");
                    arms.LocalDescarga = objList.Valor("LocalDescarga");
                    arms.HoraDescarga = objList.Valor("HoraDescarga");

                    listArms.Add(arms);
                    objList.Seguinte();
                }

                return listArms;

            }
            else
            {
                return null;

            }
        }

        #endregion Documento;

        public static List<Model.FaturaPendente> ListaFaturasPendentes()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.FaturaPendente fatura = new Model.FaturaPendente();
            List<Model.FaturaPendente> listFaturas = new List<Model.FaturaPendente>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

               // objList = PriEngine.Engine.Comercial.Pendentes.LstPendentesCliente("C0001");
                objList = PriEngine.Engine.Consulta("SELECT NumDoc, TotalMerc, Moeda, DataVencimento, TipoDoc From CabecDoc");

                while (!objList.NoFim())
                {
                    fatura = new Model.FaturaPendente();
                    fatura.NumDoc = objList.Valor("NumDoc");
                    fatura.TotalMerc = objList.Valor("TotalMerc");
                    fatura.Moeda = objList.Valor("Moeda");
                    fatura.DataVencimento = objList.Valor("DataVencimento");
                    fatura.TipoDoc = objList.Valor("TipoDoc");

                    listFaturas.Add(fatura);
                    objList.Seguinte();
                }

                return listFaturas;
            }
            else
            {
                return null;

            }
        }

        public static Lib_Primavera.Model.FaturaPendente GetFatura(string codFatura)
        {
            return null;
        }
        public static List<Model.DocCompra> VGR_List()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();
            Model.LinhaDocCompra lindc = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindc = new List<Model.LinhaDocCompra>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras where TipoDoc='VGR'");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.NumDocExterno = objListCab.Valor("NumDocExterno");
                    dc.Entidade = objListCab.Valor("Entidade");
                    dc.NumDoc = objListCab.Valor("NumDoc");
                    dc.Data = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazem, Lote from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new Model.LinhaDocCompra();
                        lindc.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.Desconto = objListLin.Valor("Desconto1");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Lote = objListLin.Valor("Lote");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }



        public static Model.RespostaErro VGR_New(Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();


            GcpBEDocumentoCompra myGR = new GcpBEDocumentoCompra();
            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();
            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myGR.set_Entidade(dc.Entidade);
                    myGR.set_NumDocExterno(dc.NumDocExterno);
                    myGR.set_Serie(dc.Serie);
                    myGR.set_Tipodoc("VGR");
                    myGR.set_TipoEntidade("F");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dc.LinhasDoc;
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR, rl);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Compras.AdicionaLinha(myGR, lin.CodArtigo, lin.Quantidade, lin.Armazem, "", lin.PrecoUnitario, lin.Desconto);
                    }


                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myGR, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }



        // ------ Documentos de venda ----------------------



        public static Model.RespostaErro Encomendas_New(Model.DocVenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoVenda myEnc = new GcpBEDocumentoVenda();

            GcpBELinhaDocumentoVenda myLin = new GcpBELinhaDocumentoVenda();

            GcpBELinhasDocumentoVenda myLinhas = new GcpBELinhasDocumentoVenda();

            PreencheRelacaoVendas rl = new PreencheRelacaoVendas();
            List<Model.LinhaDocVenda> lstlindv = new List<Model.LinhaDocVenda>();

            try
            {
                if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.Entidade);
                    myEnc.set_Serie(dv.Serie);
                    myEnc.set_Tipodoc("ECL");
                    myEnc.set_TipoEntidade("C");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc, rl);
                    foreach (Model.LinhaDocVenda lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Vendas.AdicionaLinha(myEnc, lin.CodArtigo, lin.Quantidade, "", "", lin.PrecoUnitario, lin.Desconto);
                    }


                    // PriEngine.Engine.Comercial.Compras.TransformaDocumento(

                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Vendas.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }


        public static List<Model.DocVenda> Encomendas_List()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL'");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }


        public static Model.DocVenda Encomenda_Get(string numdoc)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(_credential_comercial, _credential_user, _credential_password) == true)
            {

                string st = "SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL' and NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);
                dv = new Model.DocVenda();
                dv.id = objListCab.Valor("id");
                dv.Entidade = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.Data = objListCab.Valor("Data");
                dv.TotalMerc = objListCab.Valor("TotalMerc");
                dv.Serie = objListCab.Valor("Serie");
                objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                listlindv = new List<Model.LinhaDocVenda>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocVenda();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("Descricao");
                    lindv.Quantidade = objListLin.Valor("Quantidade");
                    lindv.Unidade = objListLin.Valor("Unidade");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                    lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

    }
}