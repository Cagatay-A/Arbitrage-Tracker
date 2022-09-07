using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace OnlineArbitraj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList exchangelist = new ArrayList()
        {
            "https://api.gateio.ws/api/v1/tickers",
            "https://api.p2pb2b.com/api/v2/public/tickers",
            "https://whitebit.com/api/v1/public/tickers",
            "https://poloniex.com/public?command=returnTicker",
            "https://api.coinex.com/v1/market/ticker/all",
            "https://indodax.com/api/ticker_all",
            "https://exmarkets.com/api/trade/v1/market/ticker",
            "https://api.tidex.com/api/v1/public/tickers",
            "https://api.exmo.com/v1.1/ticker",
            "https://marketcap.backend.currency.com/api/v1/ticker",
            "https://www.bitexen.com/api/v1/ticker/",
            "https://api.binance.com/api/v3/ticker/24hr",
            "https://ftx.com/api/markets",
            "https://api.huobi.pro/market/tickers",
            "https://openapi-sandbox.kucoin.com/api/v1/symbols",
            "https://api.kraken.com/0/public/AssetPairs",
            "https://api.crypto.com/v1/ticker",
            "https://api-cloud.bitmart.com/spot/v1/ticker",
            "https://api.bitfinex.com/v1/tickers",
            "https://www.okcoin.com/api/spot/v3/instruments/ticker",
            "https://openapi.digifinex.com/v3/ticker",
            "https://api.bitget.com/api/spot/v1/market/tickers",
            "https://api.coinstore.com/api/v1/market/tickers",
            "https://api.bitso.com/v3/ticker/",
            "https://api.aax.com/v2/market/tickers",
            "https://www.bitrue.com/api/v1/ticker/24hr",
            "https://api.bibox.com/v3/mdata/tickers",
            "https://api.latoken.com/api/v1/marketData/tickers",
            "https://api-testnet.bybit.com/v2/public/tickers",
            "https://v3.paribu.com/app/ticker",
            "https://api.btse.com/spot/api/v3.2/market_summary",
            "https://gate.kickex.com/api/v1/market/allTickers",
            "https://api.luno.com/api/1/tickers",
            "https://api.coinfield.com/v1/tickers/",
            "https://exchange-api.lcx.com/market/tickers",
            "https://api.delta.exchange/v2/tickers",
            "https://api-swap-rest.bingbon.pro/api/v1/market/getTicker",
            "https://api.btcturk.com/api/v2/ticker",
            "https://api.probit.com/api/exchange/v1/ticker",
            "https://tokpie.com/api_ticker/"

            /*"https://api.tardis.dev/v1/data-feeds/upbit?from=2021-09-01&filters=[{%22channel%22:%22ticker%22,%22symbols%22:[%22KRW-BTC%22]}]&offset=0",
            "https://api.bithumb.com/public/ticker/ALL",
            "https://api.hotbit.io/api/v1/allticker",
            "https://api.hoolgd.com/open/v1/tickers/market",
            "https://api.exchange.bitpanda.com/public/v1/market-ticker",*/
            };


        // ------------------------ExchangeVariables--------------------------
        public string[] GateioSymbol;
        public double[] GateioPrice;
        public string[] GateioKeyList = { "", "last" };
        //"https://api.gateio.ws/api/v1/tickers",

        public string[] P2pb2bSymbol;
        public double[] P2pb2bPrice;
        public string[] P2pb2bKeyList = { "", "last" };
        //"https://api.p2pb2b.com/api/v2/public/tickers",

        public string[] WhitebitSymbol;
        public double[] WhitebitPrice;
        public string[] WhitebitKeyList = { "", "last" };
        //"https://whitebit.com/api/v1/public/tickers",

        public string[] PoloniexSymbol;
        public double[] PoloniexPrice;
        public string[] PoloniexKeyList = { "", "last" };
        //"https://poloniex.com/public?command=returnTicker",

        public string[] CoinexSymbol;
        public double[] CoinexPrice;
        public string[] CoinexKeyList = { "", "last" };
        //"https://api.coinex.com/v1/market/ticker/all",

        public string[] IndodaxSymbol;
        public double[] IndodaxPrice;
        public string[] IndodaxKeyList = { "", "last" };
        //"https://indodax.com/api/ticker_all",

        public string[] ExmarketsSymbol;
        public double[] ExmarketsPrice;
        public string[] ExmarketsKeyList = { "", "last" };
        //"https://exmarkets.com/api/trade/v1/market/ticker",

        public string[] TidexSymbol;
        public double[] TidexPrice;
        public string[] TidexKeyList = { "", "last" };
        //"https://api.tidex.com/api/v1/public/tickers",

        public string[] ExmoSymbol;
        public double[] ExmoPrice;
        public string[] ExmoKeyList = { "", "buy_price" };
        //"https://api.exmo.com/v1.1/ticker",

        public string[] MarketcapSymbol;
        public double[] MarketcapPrice;
        public string[] MarketcapKeyList = { "base_currency", "quote_currency", "last_price" };
        //"https://marketcap.backend.currency.com/api/v1/ticker",

        public string[] BitexenSymbol;
        public double[] BitexenPrice;
        public string[] ProbiteKeyList = { "base_currency_code", "counter_currency_code", "last_price" };
        //"https://www.bitexen.com/api/v1/ticker/",

        public string[] BinanceSymbol;
        public double[] BinancePrice;
        public string[] BinanceKeyList = { "symbol", "lastPrice" };
        //"https://api.binance.com/api/v3/ticker/24hr", 

        public string[] FtxSymbol;
        public double[] FtxPrice;
        public string[] FtxKeyList = { "name", "last" };
        //"https://ftx.com/api/markets",

        public string[] HuobiSymbol;
        public double[] HuobiPrice;
        public string[] HuobiKeyList = { "symbol", "close" };
        //"https://api.huobi.pro/market/tickers",

        public string[] KucoinSymbol;
        public double[] KucoinPrice;
        public string[] KucoinKeyList = { "symbol", "lastPrice" };
        //"https://openapi-sandbox.kucoin.com/api/v1/symbols",
  
        public string[] KrakenSymbol;
        public double[] KrakenPrice;
        public string[] KrakenKeyList = { "symbol", "lastPrice" };
        //"https://api.kraken.com/0/public/AssetPairs",

        public string[] CryptoSymbol;
        public double[] CryptoPrice;
        public string[] CryptoKeyList = { "symbol", "last" };
        //"https://api.crypto.com/v1/ticker",

        public string[] BitmartSymbol;
        public double[] BitmartPrice;
        public string[] BitmartKeyList = { "symbol", "last_price" };
        //"https://api-cloud.bitmart.com/spot/v1/ticker",

        public string[] BitfinexSymbol;
        public double[] BitfinexPrice;
        public string[] BitfinexKeyList = { "pair", "last_price" };
        //"https://api.bitfinex.com/v1/tickers",

        public string[] OkcoinSymbol;
        public double[] OkcoinPrice;
        public string[] OkcoinKeyList = { "product_id", "last" };
        //"https://www.okcoin.com/api/spot/v3/instruments/ticker",

        public string[] DigifinexSymbol;
        public double[] DigifinexPrice;
        public string[] DigifinexKeyList = { "symbol", "last" };
        //"https://openapi.digifinex.com/v3/ticker",

        public string[] BitgetSymbol;
        public double[] BitgetPrice;
        public string[] BitgetKeyList = { "symbol", "buyOne" };
        //"https://api.bitget.com/api/spot/v1/market/tickers",

        public string[] CoinstoreSymbol;
        public double[] CoinstorePrice;
        public string[] CoinstoreKeyList = { "symbol", "close" };
        //"https://api.coinstore.com/api/v1/market/tickers",

        public string[] BitsoSymbol;
        public double[] BitsoPrice;
        public string[] BitsoKeyList = { "book", "last" };
        //"https://api.bitso.com/v3/ticker/",

        public string[] AaxSymbol;
        public double[] AaxPrice;
        public string[] AaxKeyList = { "s", "c" };
        //"https://api.aax.com/v2/market/tickers",

        public string[] BitrueSymbol;
        public double[] BitruePrice;
        public string[] BitrueKeyList = { "symbol", "lastPrice" };
        //"https://www.bitrue.com/api/v1/ticker/24hr",

        public string[] BiboxSymbol;
        public double[] BiboxPrice;
        public string[] BiboxKeyList = { "pair", "last" };
        //"https://api.bibox.com/v3/mdata/tickers",

        public string[] LatokenSymbol;
        public double[] LatokenPrice;
        public string[] LatokenKeyList = { "symbol", "close" };
        //"https://api.latoken.com/api/v1/marketData/tickers",
        
        public string[] BybitSymbol;
        public double[] BybitPrice;
        public string[] BybitKeyList = { "symbol", "last_price" };
        //"https://api-testnet.bybit.com/v2/public/tickers",

        public string[] ParibuSymbol;
        public double[] ParibuPrice;
        public string[] ParibuKeyList = { "pair", "close" };
        //"https://v3.paribu.com/app/ticker",

        public string[] BtseSymbol;
        public double[] BtsePrice;
        public string[] BtseKeyList = { "symbol", "last" };
        //"https://api.btse.com/spot/api/v3.2/market_summary",

        public string[] KickexSymbol;
        public double[] KickexPrice;
        public string[] KickexKeyList = { "pairName", "lastPrice" };
        //"https://gate.kickex.com/api/v1/market/allTickers",

        public string[] LunoSymbol;
        public double[] LunoPrice;
        public string[] LunoKeyList = { "pair", "bid" };
        //"https://api.luno.com/api/1/tickers",

        public string[] CoinfieldSymbol;
        public double[] CoinfieldPrice;
        public string[] CoinfieldKeyList = { "last", "market_id" };
        //"https://api.coinfield.com/v1/tickers/",

        public string[] LcxSymbol;
        public double[] LcxPrice;
        public string[] LcxKeyList = { "symbol", "lastPrice" };
        //"https://exchange-api.lcx.com/market/tickers",

        public string[] DeltaSymbol;
        public double[] DeltaPrice;
        public string[] DeltaKeyList = { "symbol", "spot_price" };
        //"https://api.delta.exchange/v2/tickers",

        public string[] BigbonSymbol;
        public double[] BigbonPrice;
        public string[] BigbonKeyList = { "symbol", "lastPrice" };
        //"https://api-swap-rest.bingbon.pro/api/v1/market/getTicker",

        public string[] BtcturkSymbol;
        public double[] BtcturkPrice;
        public string[] BtcturkKeyList = { "pairNormalized", "last" };
        //"https://api.btcturk.com/api/v2/ticker",

        public string[] ProbiteSymbol;
        public double[] ProbitePrice;
        public string[] KeyList = { "market_id", "last" };
        //"https://api.probit.com/api/exchange/v1/ticker",

        public string[] TokpieSymbol;
        public double[] TokpiePrice;
        public string[] TokpieKeyList = { "pair", "last" };
        //"https://tokpie.com/api_ticker/",

        // ------------------------------

        /*public string[] UpbitSymbol;
        public double[] UpbitPrice;
        public string[] UpbitKeyList = { "symbol", "lastPrice" };
        "https://api.tardis.dev/v1/data-feeds/upbit?from=2021-09-01&filters=[{%22channel%22:%22ticker%22,%22symbols%22:[%22KRW-BTC%22]}]&offset=0",*/

        /*public string[] BithumbSymbol;
        public double[] BithumbPrice;
        public string[] BithumbKeyList = { "symbol", "lastPrice" };
        "https://api.bithumb.com/public/ticker/ALL",*/

        /*public string[] HotbithSymbol;
        public double[] HotbithPrice;
        public string[] HotbithKeyList = { "symbol", "lastPrice" };
        "https://api.hotbit.io/api/v1/allticker",*/

        /*public string[] HoolgdSymbol;
        public double[] HoolgdPrice;
        public string[] HoolgdKeyList = { "symbol", "lastPrice" };
        "https://api.hoolgd.com/open/v1/tickers/market",*/

        /*public string[] BitpandaSymbol;
        public double[] BitpandaPrice;
        public string[] BitpandaKeyList = { "symbol", "lastPrice" };
        "https://api.exchange.bitpanda.com/public/v1/market-ticker",*/

        // ------------------------ExchangeVariables--------------------------

        public string[] SelectedSymbols;
        public int[] SelectedIndis;



        private void button1_Click_1(object sender, EventArgs e)
        {

            if (checkedListBox2.CheckedItems.Count > 0)
            {
                /*
                    public string[] BinanceSymbol;
                    public double[] BinancePrice;
                    public string[] BinanceKeyList = { "symbol", "lastPrice" };
                    //"https://api.binance.com/api/v3/ticker/24hr", 
                */


                for (int i = 0; i < exchangelist.Count; i++)
                {
                    string Link = exchangelist[i].ToString();
                    WebRequest Symboles = HttpWebRequest.Create(Link);
                    WebResponse ReturnAnsver = Symboles.GetResponse();
                    StreamReader ReadAnswer = new StreamReader(ReturnAnsver.GetResponseStream());
                    string SourceCode = ReadAnswer.ReadToEnd();
                    JArray arraySymbol = JArray.Parse(SourceCode);
                    int SymbolLength = (arraySymbol.Count - 1);


                    BinanceSymbol = new string[SymbolLength + 1];
                    BinancePrice = new double[SymbolLength + 1];

                    int index = 0;
                    string symbolkey = BinanceKeyList[0].ToString();
                    string pricekey = BinanceKeyList[1].ToString();

                    foreach (var obj in arraySymbol)
                    {
                        string symbol = obj[symbolkey].ToString();
                        double price = Convert.ToDouble(obj[pricekey]);

                        BinanceSymbol[index] = symbol.ToString();
                        BinancePrice[index] = price;

                        index++;
                    }

                }//FOR
            }//IF
            else
            {
                MessageBox.Show("Lütfen listeden en az 1 eleman seçiniz.", "CheckedItems", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//Else

        }//Object's

        private void textBox48_MouseClick(object sender, MouseEventArgs e)
        {
            textBox48.Text = "";
        }

        private void textBox49_MouseClick(object sender, MouseEventArgs e)
        {
            textBox48.Text = "";
        }

        private void textBox48_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                string key = textBox48.Text.ToString();

                int sayı = checkedListBox2.FindString(textBox48.Text);
                checkedListBox2.SetItemChecked(sayı, true);

            }


        }



        private void button2_Click(object sender, EventArgs e)
        {
            //checkedListBox1.SetItemChecked = true;
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int array_length = checkedListBox2.CheckedItems.Count;



            SelectedSymbols = new string[array_length];
            SelectedIndis = new int[array_length];
            int i = 0;
            if (checkedListBox2.CheckedItems.Count > 0)
            {
                foreach (string title in checkedListBox2.CheckedItems)
                {
                    SelectedSymbols[i] = title;
                    SelectedIndis[i] = i;

                    i++;


                }
                checkedListBox3.Items.Clear();
                for (int j = 0; j <= SelectedSymbols.Length - 1; j++)
                {
                    //checkedListBox3.
                    string key = SelectedSymbols[j];
                    // string key = checkedListBox2.SelectedIndex[indis].toString();

                    checkedListBox3.Items.Add(key, true);
                }



            }



        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {



            string Value = checkedListBox3.SelectedItem.ToString();
            int Indis = checkedListBox3.SelectedIndex;


            for (int i = 0; i < SelectedSymbols.Length; i++)
            {
                if (SelectedSymbols[i] == Value)
                {

                    checkedListBox3.Items.Clear();

                    List<string> tmp1 = new List<string>(SelectedSymbols);
                    tmp1.RemoveAt(Indis);
                    SelectedSymbols = tmp1.ToArray();

                    List<int> tmp2 = new List<int>(SelectedIndis);
                    tmp2.RemoveAt(Indis);
                    SelectedIndis = tmp2.ToArray();
                    checkedListBox2.SetItemChecked(Indis, false);

                    for (int k = 0; k <= SelectedSymbols.Length - 1; k++)
                    {
                        string key = SelectedSymbols[k];
                        checkedListBox3.Items.Add(key, true);
                    }
                }
            }

        }


    }
}
