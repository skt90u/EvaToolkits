﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本: 11.0.0.0
//  
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace SmasToolkit
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public partial class DetailPageGenerator_JavascriptTemplate : DetailPageGenerator_JavascriptTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("function btnDELETE_Click() {\r\n\treturn confirm(\"確定是否刪除此筆資料?\");\r\n}\r\n\r\nfunction btnC" +
                    "LEAR_Click() {\r\n\tclearText($(\"#form1\")[0].elements);\r\n\r\n    // 如果使用clearText仍然沒有" +
                    "完全清空資料，請再加入以下要清空的欄位\r\n\t");
            
            #line 15 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"

		PushIndent("	");

		foreach (var column in config.Columns)
		{
			WriteLine("// {0};", column.SetJsonValue(string.Empty));
		}

		ClearIndent();
	
            
            #line default
            #line hidden
            this.Write("\r\n\treturn false; // 避免 postback\r\n}\r\n\r\nfunction btnSave_Click() {\r\n\r\n    // 清空錯誤訊息" +
                    "\r\n\tInitErr();\r\n\r\n    var buttonType = ($(\"#hidACT_TYPE\").val() || \'\').trim().toU" +
                    "pperCase(); // 上一頁執行的動作(修改UPD, 查詢QRY, 複製COPY, 新增ADD, 刪除DEL)\r\n\r\n    // 自訂檢驗(必填欄位)" +
                    "\r\n\t");
            
            #line 37 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"

		PushIndent("	");

		foreach (var column in config.Columns)
		{
            if (column.IsRequired || column.IsPrimaryKey)
            {
                WriteLine("ErrCtrl($('#{0}'), '{1}格式錯誤!', validationEngine, 'check{2}');", column.GetInputId(), column.Desc, column.Name);
            }
		}

		ClearIndent();
	
            
            #line default
            #line hidden
            this.Write("\r\n    // 自訂檢驗(非必填欄位，有輸入才檢驗)\r\n\t");
            
            #line 52 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"

		PushIndent("	");

		foreach (var column in config.Columns)
		{
            if (!column.IsRequired && !column.IsPrimaryKey)
            {
                WriteLine("//if ({0} != '')", column.GetJsonValue());
			    WriteLine("//	ErrCtrl($('#{0}'), '{1}格式錯誤!', validationEngine, 'check{2}');", column.GetInputId(), column.Desc, column.Name);
            }
		}

		ClearIndent();
	
            
            #line default
            #line hidden
            this.Write("\r\n    // 當主主頁執行的動作為(複製COPY, 新增ADD)，需要檢驗主鍵值是否重複\r\n\tif (buttonType == \"ADD\" || butto" +
                    "nType == \"COPY\") {\r\n\t\t");
            
            #line 69 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"

			PushIndent("		");
            
			foreach (var column in config.Columns)
			{
                if (column.IsPrimaryKey)
                {
                    WriteLine("ErrCtrl($('#{0}'), '{1}已經存在,請確認!', validationEngine, 'DoesDataAlreadyExist'); // 如果{0}不是主鍵值欄位，請移除這一行", column.GetInputId(), column.Desc);
                }
			}

			ClearIndent();
		
            
            #line default
            #line hidden
            this.Write("\t}\r\n\r\n    // 執行預設檢驗項目(AllowEmpty, TypeMode==number, TypeMode==date || TypeMode==d" +
                    "ateR, DataFormat)\r\n\treturn isValid();\r\n}\r\n\r\nvar validationEngine = {\r\n\t// 自訂驗證方法" +
                    "\r\n\t");
            
            #line 90 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"

		PushIndent("	");

		foreach (var column in config.Columns)
		{
			WriteLine("check{0}: function () {{ return true; }},", column.Name);
		}

		ClearIndent();
	
            
            #line default
            #line hidden
            this.Write("\tDoesDataAlreadyExist: function () {\r\n\t\tvar result = true;\r\n\r\n\t\t// 將所有欄位傳上去\r\n\t\tva" +
                    "r data = JSON.stringify({ \r\n\t\t\t");
            
            #line 105 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"

				PushIndent("			");

				foreach (var hc in config.Columns)
				{
					WriteLine("p_{0}: {1} || '',", hc.Name, hc.GetJsonValue());
				}

				ClearIndent();
			
            
            #line default
            #line hidden
            this.Write("\t\t});\r\n\r\n\t\t$.ajax({\r\n\t\t\ttype: \"POST\",\r\n\t\t\tasync: false, // 同步呼叫，等待此呼叫結束，才回傳結果\r\n\t\t" +
                    "\turl: \"");
            
            #line 120 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(config.ParentPageId));
            
            #line default
            #line hidden
            this.Write(@".aspx/DoesDataAlreadyExist"",
			data: data,
			contentType: ""application/json; charset=utf-8"",
			dataType: ""json"",
			error: function (jqXHR, textStatus, errorThrown) {
				alert(jqXHR.responseText);
                result = true;
			},
			success: function (data, textStatus, jqXHR) {
				result = !(data.d);
			}
		});

		return result;
	}
};
");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Backup\Markdown\EvaToolkits\SmasToolkit\DetailPageGenerator_JavascriptTemplate.tt"

private global::SmasToolkit.DetailPageGeneratorConfig _configField;

/// <summary>
/// Access the config parameter of the template.
/// </summary>
private global::SmasToolkit.DetailPageGeneratorConfig config
{
    get
    {
        return this._configField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool configValueAcquired = false;
if (this.Session.ContainsKey("config"))
{
    if ((typeof(global::SmasToolkit.DetailPageGeneratorConfig).IsAssignableFrom(this.Session["config"].GetType()) == false))
    {
        this.Error("參數 \'config\' 的型別 \'SmasToolkit.DetailPageGeneratorConfig\' 不符合傳遞至範本之資料的型別。");
    }
    else
    {
        this._configField = ((global::SmasToolkit.DetailPageGeneratorConfig)(this.Session["config"]));
        configValueAcquired = true;
    }
}
if ((configValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("config");
    if ((data != null))
    {
        if ((typeof(global::SmasToolkit.DetailPageGeneratorConfig).IsAssignableFrom(data.GetType()) == false))
        {
            this.Error("參數 \'config\' 的型別 \'SmasToolkit.DetailPageGeneratorConfig\' 不符合傳遞至範本之資料的型別。");
        }
        else
        {
            this._configField = ((global::SmasToolkit.DetailPageGeneratorConfig)(data));
        }
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "11.0.0.0")]
    public class DetailPageGenerator_JavascriptTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
