﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace TalentSearch.EmailWebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmailWebService.EmailWebServiceSoap")]
    public interface EmailWebServiceSoap {
        
        // CODEGEN: Parameter 'msgTo' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Send", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TalentSearch.EmailWebService.SendResponse Send(TalentSearch.EmailWebService.SendRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Send", ReplyAction="*")]
        System.Threading.Tasks.Task<TalentSearch.EmailWebService.SendResponse> SendAsync(TalentSearch.EmailWebService.SendRequest request);
        
        // CODEGEN: Parameter 'msgTo' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendGmail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        TalentSearch.EmailWebService.SendGmailResponse SendGmail(TalentSearch.EmailWebService.SendGmailRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendGmail", ReplyAction="*")]
        System.Threading.Tasks.Task<TalentSearch.EmailWebService.SendGmailResponse> SendGmailAsync(TalentSearch.EmailWebService.SendGmailRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Send", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SendRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string msgFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string msgTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string msgSubject;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string msgBody;
        
        public SendRequest() {
        }
        
        public SendRequest(string msgFrom, string msgTo, string msgSubject, string msgBody) {
            this.msgFrom = msgFrom;
            this.msgTo = msgTo;
            this.msgSubject = msgSubject;
            this.msgBody = msgBody;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SendResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SendResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string SendResult;
        
        public SendResponse() {
        }
        
        public SendResponse(string SendResult) {
            this.SendResult = SendResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SendGmail", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SendGmailRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string msgFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string msgTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string msgSubject;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string msgBody;
        
        public SendGmailRequest() {
        }
        
        public SendGmailRequest(string msgFrom, string msgTo, string msgSubject, string msgBody) {
            this.msgFrom = msgFrom;
            this.msgTo = msgTo;
            this.msgSubject = msgSubject;
            this.msgBody = msgBody;
        }

        public static implicit operator SendGmailRequest(EmailWebServiceSoapClient v)
        {
            throw new NotImplementedException();
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SendGmailResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class SendGmailResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string SendGmailResult;
        
        public SendGmailResponse() {
        }
        
        public SendGmailResponse(string SendGmailResult) {
            this.SendGmailResult = SendGmailResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface EmailWebServiceSoapChannel : TalentSearch.EmailWebService.EmailWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmailWebServiceSoapClient : System.ServiceModel.ClientBase<TalentSearch.EmailWebService.EmailWebServiceSoap>, TalentSearch.EmailWebService.EmailWebServiceSoap {
        
        public EmailWebServiceSoapClient() {
        }
        
        public EmailWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmailWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmailWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmailWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TalentSearch.EmailWebService.SendResponse TalentSearch.EmailWebService.EmailWebServiceSoap.Send(TalentSearch.EmailWebService.SendRequest request) {
            return base.Channel.Send(request);
        }
        
        public string Send(string msgFrom, string msgTo, string msgSubject, string msgBody) {
            TalentSearch.EmailWebService.SendRequest inValue = new TalentSearch.EmailWebService.SendRequest();
            inValue.msgFrom = msgFrom;
            inValue.msgTo = msgTo;
            inValue.msgSubject = msgSubject;
            inValue.msgBody = msgBody;
            TalentSearch.EmailWebService.SendResponse retVal = ((TalentSearch.EmailWebService.EmailWebServiceSoap)(this)).Send(inValue);
            return retVal.SendResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TalentSearch.EmailWebService.SendResponse> TalentSearch.EmailWebService.EmailWebServiceSoap.SendAsync(TalentSearch.EmailWebService.SendRequest request) {
            return base.Channel.SendAsync(request);
        }
        
        public System.Threading.Tasks.Task<TalentSearch.EmailWebService.SendResponse> SendAsync(string msgFrom, string msgTo, string msgSubject, string msgBody) {
            TalentSearch.EmailWebService.SendRequest inValue = new TalentSearch.EmailWebService.SendRequest();
            inValue.msgFrom = msgFrom;
            inValue.msgTo = msgTo;
            inValue.msgSubject = msgSubject;
            inValue.msgBody = msgBody;
            return ((TalentSearch.EmailWebService.EmailWebServiceSoap)(this)).SendAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TalentSearch.EmailWebService.SendGmailResponse TalentSearch.EmailWebService.EmailWebServiceSoap.SendGmail(TalentSearch.EmailWebService.SendGmailRequest request) {
            return base.Channel.SendGmail(request);
        }
        
        public string SendGmail(string msgFrom, string msgTo, string msgSubject, string msgBody) {
            TalentSearch.EmailWebService.SendGmailRequest inValue = new TalentSearch.EmailWebService.SendGmailRequest();
            inValue.msgFrom = msgFrom;
            inValue.msgTo = msgTo;
            inValue.msgSubject = msgSubject;
            inValue.msgBody = msgBody;
            TalentSearch.EmailWebService.SendGmailResponse retVal = ((TalentSearch.EmailWebService.EmailWebServiceSoap)(this)).SendGmail(inValue);
            return retVal.SendGmailResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TalentSearch.EmailWebService.SendGmailResponse> TalentSearch.EmailWebService.EmailWebServiceSoap.SendGmailAsync(TalentSearch.EmailWebService.SendGmailRequest request) {
            return base.Channel.SendGmailAsync(request);
        }
        
        public System.Threading.Tasks.Task<TalentSearch.EmailWebService.SendGmailResponse> SendGmailAsync(string msgFrom, string msgTo, string msgSubject, string msgBody) {
            TalentSearch.EmailWebService.SendGmailRequest inValue = new TalentSearch.EmailWebService.SendGmailRequest();
            inValue.msgFrom = msgFrom;
            inValue.msgTo = msgTo;
            inValue.msgSubject = msgSubject;
            inValue.msgBody = msgBody;
            return ((TalentSearch.EmailWebService.EmailWebServiceSoap)(this)).SendGmailAsync(inValue);
        }
    }
}