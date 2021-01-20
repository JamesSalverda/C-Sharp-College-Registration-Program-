﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BITCollegeSite.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ICollegeRegistration")]
    public interface ICollegeRegistration {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICollegeRegistration/DoWork", ReplyAction="http://tempuri.org/ICollegeRegistration/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICollegeRegistration/DoWork", ReplyAction="http://tempuri.org/ICollegeRegistration/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICollegeRegistration/dropCourse", ReplyAction="http://tempuri.org/ICollegeRegistration/dropCourseResponse")]
        bool dropCourse(int registrationId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICollegeRegistration/dropCourse", ReplyAction="http://tempuri.org/ICollegeRegistration/dropCourseResponse")]
        System.Threading.Tasks.Task<bool> dropCourseAsync(int registrationId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICollegeRegistration/registerCourse", ReplyAction="http://tempuri.org/ICollegeRegistration/registerCourseResponse")]
        int registerCourse(int studentId, int courseId, string notes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICollegeRegistration/registerCourse", ReplyAction="http://tempuri.org/ICollegeRegistration/registerCourseResponse")]
        System.Threading.Tasks.Task<int> registerCourseAsync(int studentId, int courseId, string notes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICollegeRegistration/upgradeGrade", ReplyAction="http://tempuri.org/ICollegeRegistration/upgradeGradeResponse")]
        void upgradeGrade(double grade, int registrationId, string notes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICollegeRegistration/upgradeGrade", ReplyAction="http://tempuri.org/ICollegeRegistration/upgradeGradeResponse")]
        System.Threading.Tasks.Task upgradeGradeAsync(double grade, int registrationId, string notes);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICollegeRegistrationChannel : BITCollegeSite.ServiceReference2.ICollegeRegistration, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CollegeRegistrationClient : System.ServiceModel.ClientBase<BITCollegeSite.ServiceReference2.ICollegeRegistration>, BITCollegeSite.ServiceReference2.ICollegeRegistration {
        
        public CollegeRegistrationClient() {
        }
        
        public CollegeRegistrationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CollegeRegistrationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CollegeRegistrationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CollegeRegistrationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public bool dropCourse(int registrationId) {
            return base.Channel.dropCourse(registrationId);
        }
        
        public System.Threading.Tasks.Task<bool> dropCourseAsync(int registrationId) {
            return base.Channel.dropCourseAsync(registrationId);
        }
        
        public int registerCourse(int studentId, int courseId, string notes) {
            return base.Channel.registerCourse(studentId, courseId, notes);
        }
        
        public System.Threading.Tasks.Task<int> registerCourseAsync(int studentId, int courseId, string notes) {
            return base.Channel.registerCourseAsync(studentId, courseId, notes);
        }
        
        public void upgradeGrade(double grade, int registrationId, string notes) {
            base.Channel.upgradeGrade(grade, registrationId, notes);
        }
        
        public System.Threading.Tasks.Task upgradeGradeAsync(double grade, int registrationId, string notes) {
            return base.Channel.upgradeGradeAsync(grade, registrationId, notes);
        }
    }
}
