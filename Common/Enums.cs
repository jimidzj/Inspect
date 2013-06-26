using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GENLSYS.MES.Common
{

    #region Public Enum
    /************************Public Section*************************/
    public enum Public_DateTimeType
    {
        Date,
        DateTime,
        Time
    }

    public enum Public_Status
    {
        Active,
        Inactive,
        Valid,
        Invalid
    }

    public enum Public_ValidFlag
    {
        Valid,
        Invalid
    }

    public enum Public_ActiveFlag
    {
        Active,
        Inactive
    }

    public enum Public_Flag
    {
        Y,
        N,
        X
    }

    public enum Public_DefaultValue
    {
        sysdate,
        sysuser
    }

    public enum Public_UpdateMode
    {
        Insert,
        Update,
        Delete,
        Copy
    }

    public enum Public_FlowStatus
    {
        Created,
        Active,
        Freezed,
        Abandoned
    }

    public enum Public_MessageBox
    {
        Error,
        Information,
        Exclamation,
        Question,
        Warning
    }

    public enum Public_MoveDirection
    {
        Up,
        Down
    }

    public enum Public_StaticValueType
    {
        AttributeTemplateUsedBy,
        AttributeTemplateAttributeType,
        AttributeTemplateValueType,
        RequestPayTemplate,
        Priority,
        SecurityUserType,
        EmployeeType,
        TaxType,
        CustomerType,
        InvoiceType,
        Currency,
        Unit,
        BillRuleTimeFormat,
        Sex,
        IsDefault,
        Title,
        QCCheckType,
        QCCheckResult,
        IsConfirmed,
        WOStatus,
        QCReturnType,
        CheckType,
        Year,
        Month,
        IsMixed,
        WIPStatus,
        LineGroup,
        LoadingType,
        ReturnType,
        ShoeColor,
        ShoeSize,
        ShoeCategory,
        LineAction,
        JointType
    }
    #endregion

    #region Security Enums
    /********************Security Section***********************/
    public enum Security_UserStatus
    {
        Active,
        Inactive,
        Deleted,
        Locked
    }

    public enum Security_Permission_Type
    {
        Allowed,
        Denied
    }

    #endregion

    #region Daemon Enums
    /************Daemon Service********************/
    public enum Damon_TaskExecutionResult
    {
        Successfully,
        Failed,
        Unknown
    }

    public enum Daemon_ScheduleStatus
    {
        Active,
        Inactive
    }

    public enum Daemon_ScheduleRunMode
    {
        RecoveryMode,
        NormalMode
    }

    public enum Daemon_AlarmingMsgLevel
    {
        Success,
        Fail,
        Both
    }

    public enum Daemon_TaskProcStatus
    {
        Processing,
        Idle
    }
    #endregion

    #region Alarm Enums
    /********************Alarm Section**************************/
    public enum Alarm_AlarmStatus
    {
        Handled,
        Unhandled,
        Expired,
        Abandoned,
        Abnormal
    }

    public enum Costing_CalculationStep_LockStatus
    {
        Y,
        N,
        Unknown
    }

    public enum Alarm_AlarmCatagory
    {
        PMORDER,
        PMJOB,
        EQP
    }


    public enum Alarm_AlarmType
    {
        Email,
        PhoneCall,
        SMS,
        Board

    }

    public enum Alarm_BoardStatus
    {
        All,
        Read,
        UnRead
    }

    public enum Alarm_DeliveryStatus
    {
        Sent,
        Unsent,
        Abnormal
    }
    #endregion

    #region Log Enums
    /******************Log Section*****************************/
    public enum Log_LoggingLevel
    {
        Admin,          //Keep all logs
        Normal,
        None
    }
    #endregion

    #region Exception,Error
    /********************Exception Section************************/
    public enum Exception_ExceptionSeverity
    {
        High,
        Medium,
        Low
    }

    public enum Exception_ErrorMessage
    {
        NoError = 1000,
        Pass = 1001,
        IsDuplicate = -1001,
        IsNull = -1002,
        IsUsed = -1003,
        ParameterError = -1004,
        Fail = -1005,
        IsSystemUser = -1006,
        PeriodIsClosedImportDenied = -1009,
        PeriodIsUnused = -1010,
        PeriodIsClosed = -1040,
        OpenPeriodFoundOpenDenied = -1014
    }
    #endregion

    #region MES
    public enum MES_Misc
    {
        NoAction,
        Null,
        First,
        Increment,
        Pass,
        Fail,
        Start,
        End,
        Y,
        N,
        Unknown,
        Reject,
        BadStock
    }

    public enum MES_AttributeTemplate_UsedBy
    {
        Area,
        Equipment,
        Product,
        Lot,
        Flow,
        Step,
        Rule,
        ReasonCode,
        Tools,
        TestProgram
    }

    public enum MES_AttributeTemplate_AttributeType
    {
        User,
        System
    }

    public enum MES_AttributeTemplate_ValueType
    {
        String,
        Date,
        Number
    }

    public enum MES_RevState
    {
        Created,
        Active,
        Inactive,
        Closed
    }

    public enum MES_Flag
    {
        Valid,
        Invalid
    }
    
    public enum MES_FuncType
    {
        Menu,
        Button
    }

    public enum MES_MenuType
    {
        M, //System Modeling
        W, //WIP
        E, //EQP
        R  //Reporting
    }
    public enum MES_Unit
    {
        EA,
        PC
    }

    public enum MES_SystemCode
    {
        SYS01,
        SYS02,
        SYS03,
        SYS_LOWYIELD_HOLD
    }

    public enum MES_ActionType
    {
        Query,
        Insert,
        Update,
        Delete
    }

    public enum MES_DummyData
    {
        Dummy_Data_XXX_111,
        Dummy_Data_XXX_222,
        Dummy_Data_YYY_111,
        Dummy_Data_YYY_222
    }

    public enum MES_BillCodeRule_BCRStatus
    {
        Unused,
        Used,
        Closed
    }

    public enum MES_BillCodeRule_BCRBaseValue
    {
        TimeFormat,
        Parameter,
        Both
    }

    public enum MES_PSStatus
    {
        Schedule,
        Packing,
        Terminated,
        Completed
    }

    public enum MES_PackingListStatus
    {
        Packing,
        Shipping,
        Rejected,
        Terminated,
        Completed
    }
    
    public enum MES_StaticValue_Type
    {
        AttributeTemplateUsedBy,
        AttributeTemplateAttributeType,
        AttributeTemplateValueType,
        Priority,
        SecurityUserType,
        EmployeeType,
        CustomerType,
        Currency,
        InvoiceType,
        TaxType,
        BillRuleTimeFormat,
        ShoeCategory,
        ShoeColor,
        ShoeSize,
        Unit,
        Sex,
        IsDefault,
        Title,
        QCCheckType,
        QCCheckResult,
        QCReturnType,
        IsConfirmed,
        WOStatus,
        CheckType,
        Year,
        Month,
        Step, 
        LoadingType,
        ReturnType,
        LineGroup, 
        IsMixed,
        CartonStatus,
        WIPStatus,
        Factory,
        LineAction,
        RequestPayTemplate,
        JointType
    }

    public enum MES_ReasonCategory
    {
        Skip,
        Terminate,
        Hold,
        Release,
        Rework,
        TrackInCancel,
        Split,
        Merge,
        Fail,
        EqpState,
        AdjustLot,
        GradeDemotion,
        Scrap,
        UNScrap,
        Pass,
        UpdateLot,
        InkFail,
        PassStep,
        Repair

    }


    #endregion

    #region Inspection
    public enum MES_WOType_Flag
    {
        In,
        Out,
        Adjust,
        Move,
        Scrap,
        Return
    }

    public enum MES_WOType_Status
    {
        Valid,
        Invalid
    }

    public enum MES_Warehouse_Flag
    {
        Normal,
        Scrap
    }

    public enum MES_Warehouse_Status
    {
        Valid,
        Invalid
    }

    public enum MES_Location_Flag
    {
        IQC,
        OQC,
        Normal
    }

    public enum MES_Location_Status
    {
        Valid,
        Invalid
    }

    public enum MES_CustOrder_Status
    { 
        Create,
        Active,
        Cancelled,
        Finished
    }

    public enum MES_CartonStatus
    {
        Active,
        Terminated,
        Finished
    }

    public enum MES_CartonLocation
    { 
        Warehouse,
        Returned,
        WIP,
        Shipped
    }

    public enum MES_Step
    {
        Inspection,
        XRay,
        InspectionXRay
    }

    public enum MES_RepairType
    {
        ToRepair,
        RepairSuccess,
        RepairFail
    }

    public enum MES_WIPStatus
    {
        I,
        X,
        IX,
        BAD,
        Repair
    }

    public enum MES_IsMixed_Flag
    {
        Y,
        N
    }

    public enum MES_LineType
    {
        Original,
        Adjustment
    }

    public enum MES_ShippingStatus
    {
        Plan,
        Created,
        Shipped
    }

    public enum MES_PackingType
    {
        Unpacking,
        Packing,
        Moving,
        Shipped
    }
    #endregion
} 
