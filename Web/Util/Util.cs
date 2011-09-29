using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Globalization;
using System.Security.Permissions;

public class Util
{
    /// <summary>
    /// Recupera o código ID_FIANCA+ID_CNPJ+ID_ADITIVO
    /// da Carta Fianca
    /// </summary>
    /// <param name="chave">Chave Gerada</param>
    /// <returns></returns>
    public static string ObterIDCarta(string chave)
    {
        string retorno = "";
        string c = "";
        chave = chave.ToUpper();
        for (int i = 0; i < chave.Length; i++)
        {
            c = chave[i].ToString().Replace("7", "1");
            if (c != chave[i].ToString())
            {
                retorno += c;
                continue;
            }
            c = chave[i].ToString().Replace("P", "2");
            if (c != chave[i].ToString())
            {
                retorno += c;
                continue;
            }
            c = chave[i].ToString().Replace("9", "3");
            if (c != chave[i].ToString())
            {
                retorno += c;
                continue;
            }
            c = chave[i].ToString().Replace("1", "4");
            if (c != chave[i].ToString())
            {
                retorno += c;
                continue;
            }
            c = chave[i].ToString().Replace("6", "5");
            if (c != chave[i].ToString())
            {
                retorno += c;
                continue;
            }
            c = chave[i].ToString().Replace("8", "6");
            if (c != chave[i].ToString())
            {
                retorno += c;
                continue;
            }
            c = chave[i].ToString().Replace("D", "7");
            if (c != chave[i].ToString())
            {
                retorno += c;
                continue;
            }
            c = chave[i].ToString().Replace("5", "8");
            if (c != chave[i].ToString())
            {
                retorno += c;
                continue;
            }
            c = chave[i].ToString().Replace("4", "9");
            retorno += c;
        }
        return retorno;
    }


    /// <summary>
    /// Gera uma senha de letras aleatoria
    /// </summary>
    /// <returns></returns>
    public static string GeneratePassword()
    {
        Random rand = new Random();
        StringBuilder newpassword = new StringBuilder();
        int charlength = 6;
        for (int index = 1; index <= charlength; index++)
        {
            newpassword.Append((char)rand.Next(65, 90));
        }

        return newpassword.ToString();
    }

    /// <summary>
    /// Aplica Título à página.
    /// </summary>
    /// <param name="currentPage"></param>
    /// <param name="titulo"></param>
    public static void ApplyTitle(System.Web.UI.TemplateControl currentPage, string title)
    {
        string title_config = ConfigurationManager.AppSettings["Application.Title"];
        if (title != null)
            if (title.Trim().Length > 0)
                title_config = string.Format("{0} :: {1}", title, title_config);

        currentPage.Page.Title = title_config;
    }

    public static void Alert(System.Web.UI.TemplateControl currentPage, string message, string redirect)
    {
        string alertScript = "<script type=\"text/javascript\">" +
                           "alert('{0}');";
        alertScript = string.Format(alertScript, message);

        if (redirect != null)
            if (redirect.Trim().Length > 0)
                alertScript += string.Format("window.location.href='{0}';", redirect);

        alertScript += "</script>";

        currentPage.Page.RegisterClientScriptBlock("__alert", alertScript);
    }

    public static void AlertQuestion(System.Web.UI.TemplateControl currentPage, string message, string redirectTrue, string redirectFalse)
    {
        //string alertScript = "<script type=\"text/javascript\">" +

        string alertScript = string.Format("<script type=\"text/javascript\">ConfirmaSalvarAlert('{0}','{1}','{2}')</script>", message, redirectTrue, redirectFalse);

        //if (redirect != null)
        //    if (redirect.Trim().Length > 0)
        //        alertScript += string.Format("window.location.href='{0}';", redirect);

        //alertScript += "</script>";

        currentPage.Page.RegisterClientScriptBlock("__alert", alertScript);
    }

    public static void AlertQuestion(System.Web.UI.TemplateControl currentPage, string message, string redirectTrue)
    {
        //string alertScript = "<script type=\"text/javascript\">" +

        string alertScript = string.Format("<script type=\"text/javascript\">ConfirmaSalvarAlertEmprestimo('{0}','{1},'{2}')</script>", message, redirectTrue, null);

        currentPage.Page.RegisterClientScriptBlock("__alert", alertScript);
    }

    /// <summary>
    /// Exibe mensagem de alerta porém pode ser usado com AJAX (UpdatePanel)
    /// </summary>    
    public static void AjaxAlert(System.Web.UI.TemplateControl currentPage, string message, string redirect)
    {
        string alertScript = "alert('{0}');";
        alertScript = string.Format(alertScript, message);

        if (redirect != null)
            if (redirect.Trim().Length > 0)
                alertScript += string.Format("window.location.href='{0}';", redirect);

        ScriptManager.RegisterStartupScript(currentPage, currentPage.GetType(), "__alert", alertScript, true);
    }

    public static string GetAppKeys(string key)
    {
        return ConfigurationSettings.AppSettings[key];
    }


    public static bool IsNumber(string v)
    {
        try { Decimal.Parse(v); return true; }
        catch { return false; }
    }

    public static string FormataCNPJ(string v)
    {
        try
        {
            v.Replace(".", "").Replace("/", "").Replace("-", "");
            if (IsNumber(v))
            {
                v = string.Concat("00000000000000".Substring(0, (14 - v.Length)), v);
                v = string.Format("{0}{1}.{2}{3}{4}.{5}{6}{7}/{8}{9}{10}{11}-{12}{13}"
                    , v[0], v[1], v[2], v[3], v[4], v[5], v[6], v[7], v[8], v[9], v[10], v[11], v[12], v[13]);

            }

            return v;
        }
        catch
        {
            return "0";
        }
    }

    public static string FormataCPF(string v)
    {
        try
        {
            v.Replace(".", "").Replace("/", "").Replace("-", "");
            if (IsNumber(v))
            {
                v = string.Concat("00000000000".Substring(0, (11 - v.Length)), v);
                v = string.Format("{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}{10}"
                    , v[0], v[1], v[2], v[3], v[4], v[5], v[6], v[7], v[8], v[9], v[10]);

            }

            return v;
        }
        catch
        {
            return "0";
        }
    }

    public static string FormataTempo(string v)
    {
        try
        {
            v.Replace(",", "");
            if (IsNumber(v))
            {
                v = string.Concat("00000".Substring(0, (5 - v.Length)), v);
                v = string.Format("{0}{1}{2}{3},{4}"
                    , v[0], v[1], v[2], v[3], v[4]);

            }

            return v;
        }
        catch
        {
            return "0";
        }
    }

    public static bool EnviaEmail(
        string to,
        string subject,
        string body,
        string smtp)
    {
        try
        {
            string from = ConfigurationManager.AppSettings["Application.MailAccount"];
            string password = ConfigurationManager.AppSettings["Application.MailPassword"];

            //cria objeto com dados do e-mail 
            MailMessage objEmail = new MailMessage();

            //remetente do e-mail 
            objEmail.From = new System.Net.Mail.MailAddress(from.ToString());

            //destinatários do e-mail ->Digitado no TextBox do DetailsView + @pdcase.com.br
            objEmail.To.Add(to.ToString());

            //prioridade do e-mail 
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //formato do e-mail HTML (caso não queira HTML alocar valor false) 
            objEmail.IsBodyHtml = true;

            //título do e-mail 
            objEmail.Subject = subject.ToString();

            //corpo do e-mail 
            objEmail.Body = body;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1" 
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            //cria objeto com os dados do SMTP 
            SmtpClient objSmtp = new SmtpClient();

            //Verificamos se foi informado um smtp, caso não usamos o smtp da PDCASE
            objSmtp.Host = ConfigurationManager.AppSettings["Application.MailServer"];
            if (smtp != null)
                if (smtp.Trim().Length > 0)
                    objSmtp.Host = smtp;

            objSmtp.Credentials = new System.Net.NetworkCredential(from, password);


            //enviamos o e-mail através do método .send() 
            objSmtp.Send(objEmail);

            return true;

        }
        catch
        {
            return false;
        }
    }

    public static bool EnviaEmail(
        string[] to,
        string subject,
        string body,
        string smtp)
    {
        try
        {
            string from = ConfigurationManager.AppSettings["Application.MailAccount"];
            string password = ConfigurationManager.AppSettings["Application.MailPassword"];

            //cria objeto com dados do e-mail 
            MailMessage objEmail = new MailMessage();

            //remetente do e-mail 
            objEmail.From = new System.Net.Mail.MailAddress(from.ToString());

            //destinatários do e-mail ->Digitado no TextBox do DetailsView + @pdcase.com.br
            foreach (string item in to)
                objEmail.To.Add(item.ToString());

            //prioridade do e-mail 
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //formato do e-mail HTML (caso não queira HTML alocar valor false) 
            objEmail.IsBodyHtml = true;

            //título do e-mail 
            objEmail.Subject = subject.ToString();

            //corpo do e-mail 
            objEmail.Body = body;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1" 
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            //cria objeto com os dados do SMTP 
            SmtpClient objSmtp = new SmtpClient();

            //Verificamos se foi informado um smtp, caso não usamos o smtp da PDCASE
            objSmtp.Host = ConfigurationManager.AppSettings["Application.MailServer"];
            if (smtp != null)
                if (smtp.Trim().Length > 0)
                    objSmtp.Host = smtp;

            objSmtp.Credentials = new System.Net.NetworkCredential(from, password);


            //enviamos o e-mail através do método .send() 
            objSmtp.Send(objEmail);

            return true;

        }
        catch
        {
            return false;
        }
    }


    public static bool EnviaEmail(
        string to,
        string subject,
        string body,
        string smtp,
        string[] attach)
    {
        try
        {
            string from = ConfigurationManager.AppSettings["Application.MailAccount"];
            string password = ConfigurationManager.AppSettings["Application.MailPassword"];

            //cria objeto com dados do e-mail 
            MailMessage objEmail = new MailMessage();

            //remetente do e-mail 
            objEmail.From = new System.Net.Mail.MailAddress(from.ToString());

            //destinatários do e-mail
            objEmail.To.Add(to.ToString());

            //adiciona arquivos em anexo
            int i = 0;
            foreach (string item_atach in attach)
            {  //objEmail.Attachments.Add(new Attachment(item_atach));
                objEmail.Attachments.Insert(i, new Attachment(HttpContext.Current.Server.HtmlDecode(item_atach)));
                i++;
            }

            //prioridade do e-mail 
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //formato do e-mail HTML (caso não queira HTML alocar valor false) 
            objEmail.IsBodyHtml = true;

            //título do e-mail 
            objEmail.Subject = subject.ToString();

            //corpo do e-mail 
            objEmail.Body = body;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1" 
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            //cria objeto com os dados do SMTP 
            SmtpClient objSmtp = new SmtpClient();

            //Verificamos se foi informado um smtp, caso não usamos o smtp da PDCASE
            objSmtp.Host = ConfigurationManager.AppSettings["Application.MailServer"];
            if (smtp != null)
                if (smtp.Trim().Length > 0)
                    objSmtp.Host = smtp;

            objSmtp.Credentials = new System.Net.NetworkCredential(from, password);


            //enviamos o e-mail através do método .send() 
            objSmtp.Send(objEmail);

            return true;

        }

        catch
        {
            return false;
        }
    }


    /// <summary>
    /// Retorna um template de e-mail.
    /// </summary>
    /// <param name="path">Diretório do arquivo html ou texto a ser lido.</param>
    /// <returns>string</returns>
    public static string GetTemplate(string path)
    {
        try
        {
            if (!System.IO.File.Exists(path))
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + path;
            }

            return System.IO.File.ReadAllText(path, Encoding.GetEncoding("iso-8859-1"));
        }
        catch
        {
            return string.Empty;
        }
    }

    public static void ClearControls(params Control[] controls)
    {
        foreach (Control control in controls)
        {
            if (control is TextBox)
                ((TextBox)control).Text = string.Empty;
            if (control is DropDownList)
                ((DropDownList)control).SelectedIndex = -1;

        }
    }

    public static void ClearControls(ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control is TextBox)
                ((TextBox)control).Text = string.Empty;
            if (control is DropDownList)
                ((DropDownList)control).SelectedIndex = -1;
        }
    }


    public static bool IsCNPJ(string v)
    {
        try
        {
            v = v.Replace(".", "").Replace("/", "").Replace("-", "");

            if (!(decimal.Parse(v) > 0))
                return false;

            int[] vc = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int d1, d2;
            int r = 0;

            for (int i = 0; i < 12; i++)
                r += (int.Parse(v[i].ToString()) * vc[i + 1]);
            r = r % 11;
            d1 = (r < 2) ? 0 : (11 - r);

            r = 0;
            for (int i = 0; i < 13; i++)
                r += (int.Parse(v[i].ToString()) * vc[i]);
            r = r % 11;
            d2 = (r < 2) ? 0 : (11 - r);

            if (int.Parse(v[12].ToString()) != d1)
                return false;

            if (int.Parse(v[13].ToString()) != d2)
                return false;

            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;
        string primeiro_digito;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        primeiro_digito = cpf.Substring(0, 1);
        primeiro_digito = primeiro_digito.PadLeft(11, Convert.ToChar(primeiro_digito));

        if (cpf.EndsWith(primeiro_digito))
            return false;

        tempCpf = cpf.Substring(0, 9);
        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }
    //======================================================================= 

    public static string ConvMoney(decimal valor)
    {

        string valorMoeda = null;
        valorMoeda = string.Format("{0:n}", valor);

        return valorMoeda;
    }

    public static bool IsDate(string valor)
    {
        if (valor.Length != 10)
            return false;

        try
        {
            DateTime Data = new DateTime();
            Data = DateTime.Parse(valor);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Limpa todos os controles da Coleção de controles informado
    /// </summary>
    /// <param name="oControlCollection">Coleção de Controles</param>
    public static void LimparControles(ControlCollection oControlCollection)
    {

        // Percorre a coleção de controles
        foreach (Control oControl in oControlCollection)
        {

            // TextBox
            if (oControl is TextBox)
                ((TextBox)(oControl)).Text = string.Empty;

            // DropDownList
            if (oControl is DropDownList)
                if (((DropDownList)(oControl)).Items.Count > 0)
                    ((DropDownList)(oControl)).DataSource = null;

            // CheckBox
            if (oControl is CheckBox)
                ((CheckBox)(oControl)).Checked = false;

            // RadioButton
            if (oControl is RadioButton)
                ((RadioButton)(oControl)).Checked = false;

            // HyperLink
            if (oControl is HyperLink)
                ((HyperLink)(oControl)).Text = string.Empty;

            // Chama novamente a função
            LimparControles(oControl.Controls);

        }

    }

    /// <summary>
    /// Desabilita todos os controles da Coleção de controles informado
    /// </summary>
    /// <param name="oControlCollection">Coleção de Controles</param>
    public static void DesabilitarControles(ControlCollection oControlCollection)
    {

        // Percorre a coleção de controles
        foreach (Control oControl in oControlCollection)
        {

            // TextBox
            if (oControl is TextBox)
                ((TextBox)(oControl)).Enabled = false;

            // Button
            if (oControl is Button)
                ((Button)(oControl)).Enabled = false;

            // DropDownList
            if (oControl is DropDownList)
                ((DropDownList)(oControl)).Enabled = false;

            // CheckBox
            if (oControl is CheckBox)
                ((CheckBox)(oControl)).Enabled = false;

            // HyperLink
            if (oControl is HyperLink)
                ((HyperLink)(oControl)).Enabled = false;

            // Table
            if (oControl is Table)
                ((Table)(oControl)).Enabled = false;

            // Html Table
            if (oControl is HtmlTable)
                ((HtmlTable)(oControl)).Disabled = true;

            // Html Tabel Cell
            if (oControl is HtmlTableCell)
                ((HtmlTableCell)(oControl)).Disabled = true;

            // Html Tabel Row
            if (oControl is HtmlTableRow)
                ((HtmlTableRow)(oControl)).Disabled = true;

            // Panel
            if (oControl is Panel)
                ((Panel)(oControl)).Enabled = false;

            // Chama novamente a função
            DesabilitarControles(oControl.Controls);

        }

    }

    /// <summary>
    /// Habilita todos os controles da Coleção de controles informado
    /// </summary>
    /// <param name="oControlCollection">Coleção de Controles</param>
    public static void HabilitarControles(ControlCollection oControlCollection)
    {

        // Percorre a coleção de controles
        foreach (Control oControl in oControlCollection)
        {

            // TextBox
            if (oControl is TextBox)
                ((TextBox)(oControl)).Enabled = true;

            // Button
            if (oControl is Button)
                ((Button)(oControl)).Enabled = true;

            // DropDownList
            if (oControl is DropDownList)
                ((DropDownList)(oControl)).Enabled = true;

            // CheckBox
            if (oControl is CheckBox)
                ((CheckBox)(oControl)).Enabled = true;

            // HyperLink
            if (oControl is HyperLink)
                ((HyperLink)(oControl)).Enabled = true;

            // Table
            if (oControl is Table)
                ((Table)(oControl)).Enabled = true;

            // Html Table
            if (oControl is HtmlTable)
                ((HtmlTable)(oControl)).Disabled = false;

            // Html Tabel Cell
            if (oControl is HtmlTableCell)
                ((HtmlTableCell)(oControl)).Disabled = false;

            // Html Tabel Row
            if (oControl is HtmlTableRow)
                ((HtmlTableRow)(oControl)).Disabled = false;

            // Panel
            if (oControl is Panel)
                ((Panel)(oControl)).Enabled = true;

            // Chama novamente a função
            HabilitarControles(oControl.Controls);

        }

    }
}
