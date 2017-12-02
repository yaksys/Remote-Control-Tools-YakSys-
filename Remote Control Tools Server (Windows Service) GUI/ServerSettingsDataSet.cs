using System;
using System.Collections.Generic;
using System.Text;

/*
#pragma warning disable 1591

namespace DataSet_Server_Ver110
{
    using System;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRootAttribute("DataSet_JurikSoftServerDB")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class DataSet_JurikSoftServerDB : System.Data.DataSet
    {

        private MainSettingsDataTable tableMainSettings;

        private EventsLogDataTable tableEventsLog;

        private SecurityDataBaseDataTable tableSecurityDataBase;

        private AccessRestrictionRulesDataTable tableAccessRestrictionRules;

        private CommonSecuritySettingsDataTable tableCommonSecuritySettings;

        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public DataSet_JurikSoftServerDB()
        {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected DataSet_JurikSoftServerDB(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            :
                base(info, context, false)
        {
            if ((this.IsBinarySerialized(info, context) == true))
            {
                this.InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema))
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["MainSettings"] != null))
                {
                    base.Tables.Add(new MainSettingsDataTable(ds.Tables["MainSettings"]));
                }
                if ((ds.Tables["EventsLog"] != null))
                {
                    base.Tables.Add(new EventsLogDataTable(ds.Tables["EventsLog"]));
                }
                if ((ds.Tables["SecurityDataBase"] != null))
                {
                    base.Tables.Add(new SecurityDataBaseDataTable(ds.Tables["SecurityDataBase"]));
                }
                if ((ds.Tables["AccessRestrictionRules"] != null))
                {
                    base.Tables.Add(new AccessRestrictionRulesDataTable(ds.Tables["AccessRestrictionRules"]));
                }
                if ((ds.Tables["CommonSecuritySettings"] != null))
                {
                    base.Tables.Add(new CommonSecuritySettingsDataTable(ds.Tables["CommonSecuritySettings"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public MainSettingsDataTable MainSettings
        {
            get
            {
                return this.tableMainSettings;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public EventsLogDataTable EventsLog
        {
            get
            {
                return this.tableEventsLog;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public SecurityDataBaseDataTable SecurityDataBase
        {
            get
            {
                return this.tableSecurityDataBase;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public AccessRestrictionRulesDataTable AccessRestrictionRules
        {
            get
            {
                return this.tableAccessRestrictionRules;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public CommonSecuritySettingsDataTable CommonSecuritySettings
        {
            get
            {
                return this.tableCommonSecuritySettings;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.BrowsableAttribute(true)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet()
        {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override System.Data.DataSet Clone()
        {
            DataSet_JurikSoftServerDB cln = ((DataSet_JurikSoftServerDB)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader)
        {
            if ((this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema))
            {
                this.Reset();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["MainSettings"] != null))
                {
                    base.Tables.Add(new MainSettingsDataTable(ds.Tables["MainSettings"]));
                }
                if ((ds.Tables["EventsLog"] != null))
                {
                    base.Tables.Add(new EventsLogDataTable(ds.Tables["EventsLog"]));
                }
                if ((ds.Tables["SecurityDataBase"] != null))
                {
                    base.Tables.Add(new SecurityDataBaseDataTable(ds.Tables["SecurityDataBase"]));
                }
                if ((ds.Tables["AccessRestrictionRules"] != null))
                {
                    base.Tables.Add(new AccessRestrictionRulesDataTable(ds.Tables["AccessRestrictionRules"]));
                }
                if ((ds.Tables["CommonSecuritySettings"] != null))
                {
                    base.Tables.Add(new CommonSecuritySettingsDataTable(ds.Tables["CommonSecuritySettings"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ReadXml(reader);
                this.InitVars();
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable()
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable)
        {
            this.tableMainSettings = ((MainSettingsDataTable)(base.Tables["MainSettings"]));
            if ((initTable == true))
            {
                if ((this.tableMainSettings != null))
                {
                    this.tableMainSettings.InitVars();
                }
            }
            this.tableEventsLog = ((EventsLogDataTable)(base.Tables["EventsLog"]));
            if ((initTable == true))
            {
                if ((this.tableEventsLog != null))
                {
                    this.tableEventsLog.InitVars();
                }
            }
            this.tableSecurityDataBase = ((SecurityDataBaseDataTable)(base.Tables["SecurityDataBase"]));
            if ((initTable == true))
            {
                if ((this.tableSecurityDataBase != null))
                {
                    this.tableSecurityDataBase.InitVars();
                }
            }
            this.tableAccessRestrictionRules = ((AccessRestrictionRulesDataTable)(base.Tables["AccessRestrictionRules"]));
            if ((initTable == true))
            {
                if ((this.tableAccessRestrictionRules != null))
                {
                    this.tableAccessRestrictionRules.InitVars();
                }
            }
            this.tableCommonSecuritySettings = ((CommonSecuritySettingsDataTable)(base.Tables["CommonSecuritySettings"]));
            if ((initTable == true))
            {
                if ((this.tableCommonSecuritySettings != null))
                {
                    this.tableCommonSecuritySettings.InitVars();
                }
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass()
        {
            this.DataSetName = "DataSet_JurikSoftServerDB";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DataSet_JurikSoftServerDB.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableMainSettings = new MainSettingsDataTable();
            base.Tables.Add(this.tableMainSettings);
            this.tableEventsLog = new EventsLogDataTable();
            base.Tables.Add(this.tableEventsLog);
            this.tableSecurityDataBase = new SecurityDataBaseDataTable();
            base.Tables.Add(this.tableSecurityDataBase);
            this.tableAccessRestrictionRules = new AccessRestrictionRulesDataTable();
            base.Tables.Add(this.tableAccessRestrictionRules);
            this.tableCommonSecuritySettings = new CommonSecuritySettingsDataTable();
            base.Tables.Add(this.tableCommonSecuritySettings);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeMainSettings()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeEventsLog()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeSecurityDataBase()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeAccessRestrictionRules()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeCommonSecuritySettings()
        {
            return false;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove))
            {
                this.InitVars();
            }
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs)
        {
            DataSet_JurikSoftServerDB ds = new DataSet_JurikSoftServerDB();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            return type;
        }

        public delegate void MainSettingsRowChangeEventHandler(object sender, MainSettingsRowChangeEvent e);

        public delegate void EventsLogRowChangeEventHandler(object sender, EventsLogRowChangeEvent e);

        public delegate void SecurityDataBaseRowChangeEventHandler(object sender, SecurityDataBaseRowChangeEvent e);

        public delegate void AccessRestrictionRulesRowChangeEventHandler(object sender, AccessRestrictionRulesRowChangeEvent e);

        public delegate void CommonSecuritySettingsRowChangeEventHandler(object sender, CommonSecuritySettingsRowChangeEvent e);

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class MainSettingsDataTable : System.Data.DataTable, System.Collections.IEnumerable
        {

            private System.Data.DataColumn columnID;

            private System.Data.DataColumn columnAppVersion;

            private System.Data.DataColumn columnShowToolTips;

            private System.Data.DataColumn columnShowAdvancedSettings;

            private System.Data.DataColumn columnCurrentAppLanguage;

            private System.Data.DataColumn columnAutoRun;

            private System.Data.DataColumn columnStartServerAtRun;

            private System.Data.DataColumn columnMinimizeToNotifyAreaAtRun;

            private System.Data.DataColumn columnShowIconInNotifyArea;

            private System.Data.DataColumn columnPromptPasswordAfterUnHide;

            private System.Data.DataColumn columnServerPort;

            private System.Data.DataColumn columnActivateHiddenModeAtStartUp;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public MainSettingsDataTable()
            {
                this.TableName = "MainSettings";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal MainSettingsDataTable(System.Data.DataTable table)
            {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace))
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected MainSettingsDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IDColumn
            {
                get
                {
                    return this.columnID;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn AppVersionColumn
            {
                get
                {
                    return this.columnAppVersion;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ShowToolTipsColumn
            {
                get
                {
                    return this.columnShowToolTips;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ShowAdvancedSettingsColumn
            {
                get
                {
                    return this.columnShowAdvancedSettings;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn CurrentAppLanguageColumn
            {
                get
                {
                    return this.columnCurrentAppLanguage;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn AutoRunColumn
            {
                get
                {
                    return this.columnAutoRun;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn StartServerAtRunColumn
            {
                get
                {
                    return this.columnStartServerAtRun;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MinimizeToNotifyAreaAtRunColumn
            {
                get
                {
                    return this.columnMinimizeToNotifyAreaAtRun;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ShowIconInNotifyAreaColumn
            {
                get
                {
                    return this.columnShowIconInNotifyArea;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn PromptPasswordAfterUnHideColumn
            {
                get
                {
                    return this.columnPromptPasswordAfterUnHide;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ServerPortColumn
            {
                get
                {
                    return this.columnServerPort;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ActivateHiddenModeAtStartUpColumn
            {
                get
                {
                    return this.columnActivateHiddenModeAtStartUp;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public MainSettingsRow this[int index]
            {
                get
                {
                    return ((MainSettingsRow)(this.Rows[index]));
                }
            }

            public event MainSettingsRowChangeEventHandler MainSettingsRowChanging;

            public event MainSettingsRowChangeEventHandler MainSettingsRowChanged;

            public event MainSettingsRowChangeEventHandler MainSettingsRowDeleting;

            public event MainSettingsRowChangeEventHandler MainSettingsRowDeleted;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddMainSettingsRow(MainSettingsRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public MainSettingsRow AddMainSettingsRow(int ID, string AppVersion, bool ShowToolTips, bool ShowAdvancedSettings, int CurrentAppLanguage, bool AutoRun, bool StartServerAtRun, bool MinimizeToNotifyAreaAtRun, bool ShowIconInNotifyArea, bool PromptPasswordAfterUnHide, int ServerPort, bool ActivateHiddenModeAtStartUp)
            {
                MainSettingsRow rowMainSettingsRow = ((MainSettingsRow)(this.NewRow()));
                rowMainSettingsRow.ItemArray = new object[] {
                        ID,
                        AppVersion,
                        ShowToolTips,
                        ShowAdvancedSettings,
                        CurrentAppLanguage,
                        AutoRun,
                        StartServerAtRun,
                        MinimizeToNotifyAreaAtRun,
                        ShowIconInNotifyArea,
                        PromptPasswordAfterUnHide,
                        ServerPort,
                        ActivateHiddenModeAtStartUp};
                this.Rows.Add(rowMainSettingsRow);
                return rowMainSettingsRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public MainSettingsRow FindByID(int ID)
            {
                return ((MainSettingsRow)(this.Rows.Find(new object[] {
                            ID})));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone()
            {
                MainSettingsDataTable cln = ((MainSettingsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance()
            {
                return new MainSettingsDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars()
            {
                this.columnID = base.Columns["ID"];
                this.columnAppVersion = base.Columns["AppVersion"];
                this.columnShowToolTips = base.Columns["ShowToolTips"];
                this.columnShowAdvancedSettings = base.Columns["ShowAdvancedSettings"];
                this.columnCurrentAppLanguage = base.Columns["CurrentAppLanguage"];
                this.columnAutoRun = base.Columns["AutoRun"];
                this.columnStartServerAtRun = base.Columns["StartServerAtRun"];
                this.columnMinimizeToNotifyAreaAtRun = base.Columns["MinimizeToNotifyAreaAtRun"];
                this.columnShowIconInNotifyArea = base.Columns["ShowIconInNotifyArea"];
                this.columnPromptPasswordAfterUnHide = base.Columns["PromptPasswordAfterUnHide"];
                this.columnServerPort = base.Columns["ServerPort"];
                this.columnActivateHiddenModeAtStartUp = base.Columns["ActivateHiddenModeAtStartUp"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass()
            {
                this.columnID = new System.Data.DataColumn("ID", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnID);
                this.columnAppVersion = new System.Data.DataColumn("AppVersion", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnAppVersion);
                this.columnShowToolTips = new System.Data.DataColumn("ShowToolTips", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnShowToolTips);
                this.columnShowAdvancedSettings = new System.Data.DataColumn("ShowAdvancedSettings", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnShowAdvancedSettings);
                this.columnCurrentAppLanguage = new System.Data.DataColumn("CurrentAppLanguage", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnCurrentAppLanguage);
                this.columnAutoRun = new System.Data.DataColumn("AutoRun", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnAutoRun);
                this.columnStartServerAtRun = new System.Data.DataColumn("StartServerAtRun", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnStartServerAtRun);
                this.columnMinimizeToNotifyAreaAtRun = new System.Data.DataColumn("MinimizeToNotifyAreaAtRun", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMinimizeToNotifyAreaAtRun);
                this.columnShowIconInNotifyArea = new System.Data.DataColumn("ShowIconInNotifyArea", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnShowIconInNotifyArea);
                this.columnPromptPasswordAfterUnHide = new System.Data.DataColumn("PromptPasswordAfterUnHide", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnPromptPasswordAfterUnHide);
                this.columnServerPort = new System.Data.DataColumn("ServerPort", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnServerPort);
                this.columnActivateHiddenModeAtStartUp = new System.Data.DataColumn("ActivateHiddenModeAtStartUp", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnActivateHiddenModeAtStartUp);
                this.Constraints.Add(new System.Data.UniqueConstraint("DatasetKey_MainSettings", new System.Data.DataColumn[] {
                                this.columnID}, true));
                this.columnID.AllowDBNull = false;
                this.columnID.Unique = true;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public MainSettingsRow NewMainSettingsRow()
            {
                return ((MainSettingsRow)(this.NewRow()));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new MainSettingsRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType()
            {
                return typeof(MainSettingsRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.MainSettingsRowChanged != null))
                {
                    this.MainSettingsRowChanged(this, new MainSettingsRowChangeEvent(((MainSettingsRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.MainSettingsRowChanging != null))
                {
                    this.MainSettingsRowChanging(this, new MainSettingsRowChangeEvent(((MainSettingsRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.MainSettingsRowDeleted != null))
                {
                    this.MainSettingsRowDeleted(this, new MainSettingsRowChangeEvent(((MainSettingsRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.MainSettingsRowDeleting != null))
                {
                    this.MainSettingsRowDeleting(this, new MainSettingsRowChangeEvent(((MainSettingsRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveMainSettingsRow(MainSettingsRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                DataSet_JurikSoftServerDB ds = new DataSet_JurikSoftServerDB();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "MainSettingsDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class EventsLogDataTable : System.Data.DataTable, System.Collections.IEnumerable
        {

            private System.Data.DataColumn columnID;

            private System.Data.DataColumn columnSource;

            private System.Data.DataColumn columnType;

            private System.Data.DataColumn columnDescription;

            private System.Data.DataColumn columnEventID;

            private System.Data.DataColumn columnDate;

            private System.Data.DataColumn columnTime;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public EventsLogDataTable()
            {
                this.TableName = "EventsLog";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal EventsLogDataTable(System.Data.DataTable table)
            {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace))
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected EventsLogDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IDColumn
            {
                get
                {
                    return this.columnID;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn SourceColumn
            {
                get
                {
                    return this.columnSource;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn TypeColumn
            {
                get
                {
                    return this.columnType;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn DescriptionColumn
            {
                get
                {
                    return this.columnDescription;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn EventIDColumn
            {
                get
                {
                    return this.columnEventID;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn DateColumn
            {
                get
                {
                    return this.columnDate;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn TimeColumn
            {
                get
                {
                    return this.columnTime;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public EventsLogRow this[int index]
            {
                get
                {
                    return ((EventsLogRow)(this.Rows[index]));
                }
            }

            public event EventsLogRowChangeEventHandler EventsLogRowChanging;

            public event EventsLogRowChangeEventHandler EventsLogRowChanged;

            public event EventsLogRowChangeEventHandler EventsLogRowDeleting;

            public event EventsLogRowChangeEventHandler EventsLogRowDeleted;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddEventsLogRow(EventsLogRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public EventsLogRow AddEventsLogRow(int ID, string Source, string Type, string Description, string EventID, string Date, string Time)
            {
                EventsLogRow rowEventsLogRow = ((EventsLogRow)(this.NewRow()));
                rowEventsLogRow.ItemArray = new object[] {
                        ID,
                        Source,
                        Type,
                        Description,
                        EventID,
                        Date,
                        Time};
                this.Rows.Add(rowEventsLogRow);
                return rowEventsLogRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public EventsLogRow FindByID(int ID)
            {
                return ((EventsLogRow)(this.Rows.Find(new object[] {
                            ID})));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone()
            {
                EventsLogDataTable cln = ((EventsLogDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance()
            {
                return new EventsLogDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars()
            {
                this.columnID = base.Columns["ID"];
                this.columnSource = base.Columns["Source"];
                this.columnType = base.Columns["Type"];
                this.columnDescription = base.Columns["Description"];
                this.columnEventID = base.Columns["EventID"];
                this.columnDate = base.Columns["Date"];
                this.columnTime = base.Columns["Time"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass()
            {
                this.columnID = new System.Data.DataColumn("ID", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnID);
                this.columnSource = new System.Data.DataColumn("Source", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnSource);
                this.columnType = new System.Data.DataColumn("Type", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnType);
                this.columnDescription = new System.Data.DataColumn("Description", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnDescription);
                this.columnEventID = new System.Data.DataColumn("EventID", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnEventID);
                this.columnDate = new System.Data.DataColumn("Date", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnDate);
                this.columnTime = new System.Data.DataColumn("Time", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnTime);
                this.Constraints.Add(new System.Data.UniqueConstraint("DatasetKey_EventLog", new System.Data.DataColumn[] {
                                this.columnID}, true));
                this.columnID.AllowDBNull = false;
                this.columnID.Unique = true;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public EventsLogRow NewEventsLogRow()
            {
                return ((EventsLogRow)(this.NewRow()));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new EventsLogRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType()
            {
                return typeof(EventsLogRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.EventsLogRowChanged != null))
                {
                    this.EventsLogRowChanged(this, new EventsLogRowChangeEvent(((EventsLogRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.EventsLogRowChanging != null))
                {
                    this.EventsLogRowChanging(this, new EventsLogRowChangeEvent(((EventsLogRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.EventsLogRowDeleted != null))
                {
                    this.EventsLogRowDeleted(this, new EventsLogRowChangeEvent(((EventsLogRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.EventsLogRowDeleting != null))
                {
                    this.EventsLogRowDeleting(this, new EventsLogRowChangeEvent(((EventsLogRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveEventsLogRow(EventsLogRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                DataSet_JurikSoftServerDB ds = new DataSet_JurikSoftServerDB();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "EventsLogDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class SecurityDataBaseDataTable : System.Data.DataTable, System.Collections.IEnumerable
        {

            private System.Data.DataColumn columnID;

            private System.Data.DataColumn columnUserFirstName;

            private System.Data.DataColumn columnUserLogin;

            private System.Data.DataColumn columnUserPassword;

            private System.Data.DataColumn columnCreationTime;

            private System.Data.DataColumn columnEnabledAccountState;

            private System.Data.DataColumn columnUserMiddleName;

            private System.Data.DataColumn columnUserLastName;

            private System.Data.DataColumn columnICQ;

            private System.Data.DataColumn columnCompany;

            private System.Data.DataColumn columnHomePhone;

            private System.Data.DataColumn columnWorkPhone;

            private System.Data.DataColumn columnPrivateCellular;

            private System.Data.DataColumn columnEMail;

            private System.Data.DataColumn columnUserName;

            private System.Data.DataColumn columnAccountType;

            private System.Data.DataColumn columnPermissionsLevel;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SecurityDataBaseDataTable()
            {
                this.TableName = "SecurityDataBase";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal SecurityDataBaseDataTable(System.Data.DataTable table)
            {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace))
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected SecurityDataBaseDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IDColumn
            {
                get
                {
                    return this.columnID;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn UserFirstNameColumn
            {
                get
                {
                    return this.columnUserFirstName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn UserLoginColumn
            {
                get
                {
                    return this.columnUserLogin;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn UserPasswordColumn
            {
                get
                {
                    return this.columnUserPassword;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn CreationTimeColumn
            {
                get
                {
                    return this.columnCreationTime;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn EnabledAccountStateColumn
            {
                get
                {
                    return this.columnEnabledAccountState;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn UserMiddleNameColumn
            {
                get
                {
                    return this.columnUserMiddleName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn UserLastNameColumn
            {
                get
                {
                    return this.columnUserLastName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ICQColumn
            {
                get
                {
                    return this.columnICQ;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn CompanyColumn
            {
                get
                {
                    return this.columnCompany;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn HomePhoneColumn
            {
                get
                {
                    return this.columnHomePhone;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn WorkPhoneColumn
            {
                get
                {
                    return this.columnWorkPhone;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn PrivateCellularColumn
            {
                get
                {
                    return this.columnPrivateCellular;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn EMailColumn
            {
                get
                {
                    return this.columnEMail;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn UserNameColumn
            {
                get
                {
                    return this.columnUserName;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn AccountTypeColumn
            {
                get
                {
                    return this.columnAccountType;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn PermissionsLevelColumn
            {
                get
                {
                    return this.columnPermissionsLevel;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SecurityDataBaseRow this[int index]
            {
                get
                {
                    return ((SecurityDataBaseRow)(this.Rows[index]));
                }
            }

            public event SecurityDataBaseRowChangeEventHandler SecurityDataBaseRowChanging;

            public event SecurityDataBaseRowChangeEventHandler SecurityDataBaseRowChanged;

            public event SecurityDataBaseRowChangeEventHandler SecurityDataBaseRowDeleting;

            public event SecurityDataBaseRowChangeEventHandler SecurityDataBaseRowDeleted;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddSecurityDataBaseRow(SecurityDataBaseRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SecurityDataBaseRow AddSecurityDataBaseRow(
                        int ID,
                        string UserFirstName,
                        string UserLogin,
                        string UserPassword,
                        System.DateTime CreationTime,
                        bool EnabledAccountState,
                        string UserMiddleName,
                        string UserLastName,
                        string ICQ,
                        string Company,
                        string HomePhone,
                        string WorkPhone,
                        string PrivateCellular,
                        string EMail,
                        string UserName,
                        int AccountType,
                        int PermissionsLevel)
            {
                SecurityDataBaseRow rowSecurityDataBaseRow = ((SecurityDataBaseRow)(this.NewRow()));
                rowSecurityDataBaseRow.ItemArray = new object[] {
                        ID,
                        UserFirstName,
                        UserLogin,
                        UserPassword,
                        CreationTime,
                        EnabledAccountState,
                        UserMiddleName,
                        UserLastName,
                        ICQ,
                        Company,
                        HomePhone,
                        WorkPhone,
                        PrivateCellular,
                        EMail,
                        UserName,
                        AccountType,
                        PermissionsLevel};
                this.Rows.Add(rowSecurityDataBaseRow);
                return rowSecurityDataBaseRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SecurityDataBaseRow FindByID(int ID)
            {
                return ((SecurityDataBaseRow)(this.Rows.Find(new object[] {
                            ID})));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone()
            {
                SecurityDataBaseDataTable cln = ((SecurityDataBaseDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance()
            {
                return new SecurityDataBaseDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars()
            {
                this.columnID = base.Columns["ID"];
                this.columnUserFirstName = base.Columns["UserFirstName"];
                this.columnUserLogin = base.Columns["UserLogin"];
                this.columnUserPassword = base.Columns["UserPassword"];
                this.columnCreationTime = base.Columns["CreationTime"];
                this.columnEnabledAccountState = base.Columns["EnabledAccountState"];
                this.columnUserMiddleName = base.Columns["UserMiddleName"];
                this.columnUserLastName = base.Columns["UserLastName"];
                this.columnICQ = base.Columns["ICQ"];
                this.columnCompany = base.Columns["Company"];
                this.columnHomePhone = base.Columns["HomePhone"];
                this.columnWorkPhone = base.Columns["WorkPhone"];
                this.columnPrivateCellular = base.Columns["PrivateCellular"];
                this.columnEMail = base.Columns["EMail"];
                this.columnUserName = base.Columns["UserName"];
                this.columnAccountType = base.Columns["AccountType"];
                this.columnPermissionsLevel = base.Columns["PermissionsLevel"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass()
            {
                this.columnID = new System.Data.DataColumn("ID", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnID);
                this.columnUserFirstName = new System.Data.DataColumn("UserFirstName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnUserFirstName);
                this.columnUserLogin = new System.Data.DataColumn("UserLogin", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnUserLogin);
                this.columnUserPassword = new System.Data.DataColumn("UserPassword", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnUserPassword);
                this.columnCreationTime = new System.Data.DataColumn("CreationTime", typeof(System.DateTime), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnCreationTime);
                this.columnEnabledAccountState = new System.Data.DataColumn("EnabledAccountState", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnEnabledAccountState);
                this.columnUserMiddleName = new System.Data.DataColumn("UserMiddleName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnUserMiddleName);
                this.columnUserLastName = new System.Data.DataColumn("UserLastName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnUserLastName);
                this.columnICQ = new System.Data.DataColumn("ICQ", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnICQ);
                this.columnCompany = new System.Data.DataColumn("Company", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnCompany);
                this.columnHomePhone = new System.Data.DataColumn("HomePhone", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnHomePhone);
                this.columnWorkPhone = new System.Data.DataColumn("WorkPhone", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnWorkPhone);
                this.columnPrivateCellular = new System.Data.DataColumn("PrivateCellular", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnPrivateCellular);
                this.columnEMail = new System.Data.DataColumn("EMail", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnEMail);
                this.columnUserName = new System.Data.DataColumn("UserName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnUserName);
                this.columnAccountType = new System.Data.DataColumn("AccountType", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnAccountType);
                this.columnPermissionsLevel = new System.Data.DataColumn("PermissionsLevel", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnPermissionsLevel);
                this.Constraints.Add(new System.Data.UniqueConstraint("DatasetKey_SecuritySataBase", new System.Data.DataColumn[] {
                                this.columnID}, true));
                this.columnID.AllowDBNull = false;
                this.columnID.Unique = true;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SecurityDataBaseRow NewSecurityDataBaseRow()
            {
                return ((SecurityDataBaseRow)(this.NewRow()));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new SecurityDataBaseRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType()
            {
                return typeof(SecurityDataBaseRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.SecurityDataBaseRowChanged != null))
                {
                    this.SecurityDataBaseRowChanged(this, new SecurityDataBaseRowChangeEvent(((SecurityDataBaseRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.SecurityDataBaseRowChanging != null))
                {
                    this.SecurityDataBaseRowChanging(this, new SecurityDataBaseRowChangeEvent(((SecurityDataBaseRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.SecurityDataBaseRowDeleted != null))
                {
                    this.SecurityDataBaseRowDeleted(this, new SecurityDataBaseRowChangeEvent(((SecurityDataBaseRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.SecurityDataBaseRowDeleting != null))
                {
                    this.SecurityDataBaseRowDeleting(this, new SecurityDataBaseRowChangeEvent(((SecurityDataBaseRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveSecurityDataBaseRow(SecurityDataBaseRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                DataSet_JurikSoftServerDB ds = new DataSet_JurikSoftServerDB();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "SecurityDataBaseDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class AccessRestrictionRulesDataTable : System.Data.DataTable, System.Collections.IEnumerable
        {

            private System.Data.DataColumn columnID;

            private System.Data.DataColumn columnIPRangeStartValue;

            private System.Data.DataColumn columnIPRangeEndValue;

            private System.Data.DataColumn columnIPAddress;

            private System.Data.DataColumn columnMACAddress;

            private System.Data.DataColumn columnRuleType;

            private System.Data.DataColumn columnComplementaryUseMACAddress;

            private System.Data.DataColumn columnCreationTime;

            private System.Data.DataColumn columnIsRestrictionEnabled;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public AccessRestrictionRulesDataTable()
            {
                this.TableName = "AccessRestrictionRules";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal AccessRestrictionRulesDataTable(System.Data.DataTable table)
            {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace))
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected AccessRestrictionRulesDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IDColumn
            {
                get
                {
                    return this.columnID;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IPRangeStartValueColumn
            {
                get
                {
                    return this.columnIPRangeStartValue;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IPRangeEndValueColumn
            {
                get
                {
                    return this.columnIPRangeEndValue;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IPAddressColumn
            {
                get
                {
                    return this.columnIPAddress;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MACAddressColumn
            {
                get
                {
                    return this.columnMACAddress;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn RuleTypeColumn
            {
                get
                {
                    return this.columnRuleType;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ComplementaryUseMACAddressColumn
            {
                get
                {
                    return this.columnComplementaryUseMACAddress;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn CreationTimeColumn
            {
                get
                {
                    return this.columnCreationTime;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IsRestrictionEnabledColumn
            {
                get
                {
                    return this.columnIsRestrictionEnabled;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public AccessRestrictionRulesRow this[int index]
            {
                get
                {
                    return ((AccessRestrictionRulesRow)(this.Rows[index]));
                }
            }

            public event AccessRestrictionRulesRowChangeEventHandler AccessRestrictionRulesRowChanging;

            public event AccessRestrictionRulesRowChangeEventHandler AccessRestrictionRulesRowChanged;

            public event AccessRestrictionRulesRowChangeEventHandler AccessRestrictionRulesRowDeleting;

            public event AccessRestrictionRulesRowChangeEventHandler AccessRestrictionRulesRowDeleted;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddAccessRestrictionRulesRow(AccessRestrictionRulesRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public AccessRestrictionRulesRow AddAccessRestrictionRulesRow(int ID, string IPRangeStartValue, string IPRangeEndValue, string IPAddress, string MACAddress, int RuleType, bool ComplementaryUseMACAddress, System.DateTime CreationTime, bool IsRestrictionEnabled)
            {
                AccessRestrictionRulesRow rowAccessRestrictionRulesRow = ((AccessRestrictionRulesRow)(this.NewRow()));
                rowAccessRestrictionRulesRow.ItemArray = new object[] {
                        ID,
                        IPRangeStartValue,
                        IPRangeEndValue,
                        IPAddress,
                        MACAddress,
                        RuleType,
                        ComplementaryUseMACAddress,
                        CreationTime,
                        IsRestrictionEnabled};
                this.Rows.Add(rowAccessRestrictionRulesRow);
                return rowAccessRestrictionRulesRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public AccessRestrictionRulesRow FindByID(int ID)
            {
                return ((AccessRestrictionRulesRow)(this.Rows.Find(new object[] {
                            ID})));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone()
            {
                AccessRestrictionRulesDataTable cln = ((AccessRestrictionRulesDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance()
            {
                return new AccessRestrictionRulesDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars()
            {
                this.columnID = base.Columns["ID"];
                this.columnIPRangeStartValue = base.Columns["IPRangeStartValue"];
                this.columnIPRangeEndValue = base.Columns["IPRangeEndValue"];
                this.columnIPAddress = base.Columns["IPAddress"];
                this.columnMACAddress = base.Columns["MACAddress"];
                this.columnRuleType = base.Columns["RuleType"];
                this.columnComplementaryUseMACAddress = base.Columns["ComplementaryUseMACAddress"];
                this.columnCreationTime = base.Columns["CreationTime"];
                this.columnIsRestrictionEnabled = base.Columns["IsRestrictionEnabled"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass()
            {
                this.columnID = new System.Data.DataColumn("ID", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnID);
                this.columnIPRangeStartValue = new System.Data.DataColumn("IPRangeStartValue", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnIPRangeStartValue);
                this.columnIPRangeEndValue = new System.Data.DataColumn("IPRangeEndValue", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnIPRangeEndValue);
                this.columnIPAddress = new System.Data.DataColumn("IPAddress", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnIPAddress);
                this.columnMACAddress = new System.Data.DataColumn("MACAddress", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMACAddress);
                this.columnRuleType = new System.Data.DataColumn("RuleType", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnRuleType);
                this.columnComplementaryUseMACAddress = new System.Data.DataColumn("ComplementaryUseMACAddress", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnComplementaryUseMACAddress);
                this.columnCreationTime = new System.Data.DataColumn("CreationTime", typeof(System.DateTime), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnCreationTime);
                this.columnIsRestrictionEnabled = new System.Data.DataColumn("IsRestrictionEnabled", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsRestrictionEnabled);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] {
                                this.columnID}, true));
                this.columnID.AllowDBNull = false;
                this.columnID.Unique = true;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public AccessRestrictionRulesRow NewAccessRestrictionRulesRow()
            {
                return ((AccessRestrictionRulesRow)(this.NewRow()));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new AccessRestrictionRulesRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType()
            {
                return typeof(AccessRestrictionRulesRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.AccessRestrictionRulesRowChanged != null))
                {
                    this.AccessRestrictionRulesRowChanged(this, new AccessRestrictionRulesRowChangeEvent(((AccessRestrictionRulesRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.AccessRestrictionRulesRowChanging != null))
                {
                    this.AccessRestrictionRulesRowChanging(this, new AccessRestrictionRulesRowChangeEvent(((AccessRestrictionRulesRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.AccessRestrictionRulesRowDeleted != null))
                {
                    this.AccessRestrictionRulesRowDeleted(this, new AccessRestrictionRulesRowChangeEvent(((AccessRestrictionRulesRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.AccessRestrictionRulesRowDeleting != null))
                {
                    this.AccessRestrictionRulesRowDeleting(this, new AccessRestrictionRulesRowChangeEvent(((AccessRestrictionRulesRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveAccessRestrictionRulesRow(AccessRestrictionRulesRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                DataSet_JurikSoftServerDB ds = new DataSet_JurikSoftServerDB();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "AccessRestrictionRulesDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class CommonSecuritySettingsDataTable : System.Data.DataTable, System.Collections.IEnumerable
        {

            private System.Data.DataColumn columnMinRSAKeySize;

            private System.Data.DataColumn columnMaxRSAKeySize;

            private System.Data.DataColumn columnMaxConnectionPerAccount;

            private System.Data.DataColumn columnEnableAccessRestrictions;

            private System.Data.DataColumn columnMaxConnections;

            private System.Data.DataColumn columnAllowWindowsAccounts;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public CommonSecuritySettingsDataTable()
            {
                this.TableName = "CommonSecuritySettings";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal CommonSecuritySettingsDataTable(System.Data.DataTable table)
            {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive))
                {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
                {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace))
                {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected CommonSecuritySettingsDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MinRSAKeySizeColumn
            {
                get
                {
                    return this.columnMinRSAKeySize;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MaxRSAKeySizeColumn
            {
                get
                {
                    return this.columnMaxRSAKeySize;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MaxConnectionPerAccountColumn
            {
                get
                {
                    return this.columnMaxConnectionPerAccount;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn EnableAccessRestrictionsColumn
            {
                get
                {
                    return this.columnEnableAccessRestrictions;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MaxConnectionsColumn
            {
                get
                {
                    return this.columnMaxConnections;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn AllowWindowsAccountsColumn
            {
                get
                {
                    return this.columnAllowWindowsAccounts;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public CommonSecuritySettingsRow this[int index]
            {
                get
                {
                    return ((CommonSecuritySettingsRow)(this.Rows[index]));
                }
            }

            public event CommonSecuritySettingsRowChangeEventHandler CommonSecuritySettingsRowChanging;

            public event CommonSecuritySettingsRowChangeEventHandler CommonSecuritySettingsRowChanged;

            public event CommonSecuritySettingsRowChangeEventHandler CommonSecuritySettingsRowDeleting;

            public event CommonSecuritySettingsRowChangeEventHandler CommonSecuritySettingsRowDeleted;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddCommonSecuritySettingsRow(CommonSecuritySettingsRow row)
            {
                this.Rows.Add(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public CommonSecuritySettingsRow AddCommonSecuritySettingsRow(int MinRSAKeySize, int MaxRSAKeySize, int MaxConnectionPerAccount, bool EnableAccessRestrictions, int MaxConnections, bool AllowWindowsAccounts)
            {
                CommonSecuritySettingsRow rowCommonSecuritySettingsRow = ((CommonSecuritySettingsRow)(this.NewRow()));
                rowCommonSecuritySettingsRow.ItemArray = new object[] {
                        MinRSAKeySize,
                        MaxRSAKeySize,
                        MaxConnectionPerAccount,
                        EnableAccessRestrictions,
                        MaxConnections,
                        AllowWindowsAccounts};
                this.Rows.Add(rowCommonSecuritySettingsRow);
                return rowCommonSecuritySettingsRow;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone()
            {
                CommonSecuritySettingsDataTable cln = ((CommonSecuritySettingsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance()
            {
                return new CommonSecuritySettingsDataTable();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars()
            {
                this.columnMinRSAKeySize = base.Columns["MinRSAKeySize"];
                this.columnMaxRSAKeySize = base.Columns["MaxRSAKeySize"];
                this.columnMaxConnectionPerAccount = base.Columns["MaxConnectionPerAccount"];
                this.columnEnableAccessRestrictions = base.Columns["EnableAccessRestrictions"];
                this.columnMaxConnections = base.Columns["MaxConnections"];
                this.columnAllowWindowsAccounts = base.Columns["AllowWindowsAccounts"];
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass()
            {
                this.columnMinRSAKeySize = new System.Data.DataColumn("MinRSAKeySize", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMinRSAKeySize);
                this.columnMaxRSAKeySize = new System.Data.DataColumn("MaxRSAKeySize", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMaxRSAKeySize);
                this.columnMaxConnectionPerAccount = new System.Data.DataColumn("MaxConnectionPerAccount", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMaxConnectionPerAccount);
                this.columnEnableAccessRestrictions = new System.Data.DataColumn("EnableAccessRestrictions", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnEnableAccessRestrictions);
                this.columnMaxConnections = new System.Data.DataColumn("MaxConnections", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMaxConnections);
                this.columnAllowWindowsAccounts = new System.Data.DataColumn("AllowWindowsAccounts", typeof(bool), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnAllowWindowsAccounts);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public CommonSecuritySettingsRow NewCommonSecuritySettingsRow()
            {
                return ((CommonSecuritySettingsRow)(this.NewRow()));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
            {
                return new CommonSecuritySettingsRow(builder);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType()
            {
                return typeof(CommonSecuritySettingsRow);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if ((this.CommonSecuritySettingsRowChanged != null))
                {
                    this.CommonSecuritySettingsRowChanged(this, new CommonSecuritySettingsRowChangeEvent(((CommonSecuritySettingsRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if ((this.CommonSecuritySettingsRowChanging != null))
                {
                    this.CommonSecuritySettingsRowChanging(this, new CommonSecuritySettingsRowChangeEvent(((CommonSecuritySettingsRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if ((this.CommonSecuritySettingsRowDeleted != null))
                {
                    this.CommonSecuritySettingsRowDeleted(this, new CommonSecuritySettingsRowChangeEvent(((CommonSecuritySettingsRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if ((this.CommonSecuritySettingsRowDeleting != null))
                {
                    this.CommonSecuritySettingsRowDeleting(this, new CommonSecuritySettingsRowChangeEvent(((CommonSecuritySettingsRow)(e.Row)), e.Action));
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveCommonSecuritySettingsRow(CommonSecuritySettingsRow row)
            {
                this.Rows.Remove(row);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs)
            {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                DataSet_JurikSoftServerDB ds = new DataSet_JurikSoftServerDB();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "CommonSecuritySettingsDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class MainSettingsRow : System.Data.DataRow
        {

            private MainSettingsDataTable tableMainSettings;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal MainSettingsRow(System.Data.DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableMainSettings = ((MainSettingsDataTable)(this.Table));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int ID
            {
                get
                {
                    return ((int)(this[this.tableMainSettings.IDColumn]));
                }
                set
                {
                    this[this.tableMainSettings.IDColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string AppVersion
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableMainSettings.AppVersionColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'AppVersion\' in table \'MainSettings\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.AppVersionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool ShowToolTips
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableMainSettings.ShowToolTipsColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'ShowToolTips\' in table \'MainSettings\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.ShowToolTipsColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool ShowAdvancedSettings
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableMainSettings.ShowAdvancedSettingsColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'ShowAdvancedSettings\' in table \'MainSettings\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.ShowAdvancedSettingsColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int CurrentAppLanguage
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableMainSettings.CurrentAppLanguageColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'CurrentAppLanguage\' in table \'MainSettings\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.CurrentAppLanguageColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool AutoRun
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableMainSettings.AutoRunColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'AutoRun\' in table \'MainSettings\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.AutoRunColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool StartServerAtRun
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableMainSettings.StartServerAtRunColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'StartServerAtRun\' in table \'MainSettings\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.StartServerAtRunColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool MinimizeToNotifyAreaAtRun
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableMainSettings.MinimizeToNotifyAreaAtRunColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'MinimizeToNotifyAreaAtRun\' in table \'MainSettings\' is DBNul" +
                                "l.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.MinimizeToNotifyAreaAtRunColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool ShowIconInNotifyArea
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableMainSettings.ShowIconInNotifyAreaColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'ShowIconInNotifyArea\' in table \'MainSettings\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.ShowIconInNotifyAreaColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool PromptPasswordAfterUnHide
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableMainSettings.PromptPasswordAfterUnHideColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'PromptPasswordAfterUnHide\' in table \'MainSettings\' is DBNul" +
                                "l.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.PromptPasswordAfterUnHideColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int ServerPort
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableMainSettings.ServerPortColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'ServerPort\' in table \'MainSettings\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.ServerPortColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool ActivateHiddenModeAtStartUp
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableMainSettings.ActivateHiddenModeAtStartUpColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'ActivateHiddenModeAtStartUp\' in table \'MainSettings\' is DBN" +
                                "ull.", e);
                    }
                }
                set
                {
                    this[this.tableMainSettings.ActivateHiddenModeAtStartUpColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsAppVersionNull()
            {
                return this.IsNull(this.tableMainSettings.AppVersionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetAppVersionNull()
            {
                this[this.tableMainSettings.AppVersionColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsShowToolTipsNull()
            {
                return this.IsNull(this.tableMainSettings.ShowToolTipsColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetShowToolTipsNull()
            {
                this[this.tableMainSettings.ShowToolTipsColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsShowAdvancedSettingsNull()
            {
                return this.IsNull(this.tableMainSettings.ShowAdvancedSettingsColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetShowAdvancedSettingsNull()
            {
                this[this.tableMainSettings.ShowAdvancedSettingsColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCurrentAppLanguageNull()
            {
                return this.IsNull(this.tableMainSettings.CurrentAppLanguageColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCurrentAppLanguageNull()
            {
                this[this.tableMainSettings.CurrentAppLanguageColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsAutoRunNull()
            {
                return this.IsNull(this.tableMainSettings.AutoRunColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetAutoRunNull()
            {
                this[this.tableMainSettings.AutoRunColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsStartServerAtRunNull()
            {
                return this.IsNull(this.tableMainSettings.StartServerAtRunColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetStartServerAtRunNull()
            {
                this[this.tableMainSettings.StartServerAtRunColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMinimizeToNotifyAreaAtRunNull()
            {
                return this.IsNull(this.tableMainSettings.MinimizeToNotifyAreaAtRunColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMinimizeToNotifyAreaAtRunNull()
            {
                this[this.tableMainSettings.MinimizeToNotifyAreaAtRunColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsShowIconInNotifyAreaNull()
            {
                return this.IsNull(this.tableMainSettings.ShowIconInNotifyAreaColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetShowIconInNotifyAreaNull()
            {
                this[this.tableMainSettings.ShowIconInNotifyAreaColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsPromptPasswordAfterUnHideNull()
            {
                return this.IsNull(this.tableMainSettings.PromptPasswordAfterUnHideColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetPromptPasswordAfterUnHideNull()
            {
                this[this.tableMainSettings.PromptPasswordAfterUnHideColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsServerPortNull()
            {
                return this.IsNull(this.tableMainSettings.ServerPortColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetServerPortNull()
            {
                this[this.tableMainSettings.ServerPortColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsActivateHiddenModeAtStartUpNull()
            {
                return this.IsNull(this.tableMainSettings.ActivateHiddenModeAtStartUpColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetActivateHiddenModeAtStartUpNull()
            {
                this[this.tableMainSettings.ActivateHiddenModeAtStartUpColumn] = System.Convert.DBNull;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class EventsLogRow : System.Data.DataRow
        {

            private EventsLogDataTable tableEventsLog;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal EventsLogRow(System.Data.DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableEventsLog = ((EventsLogDataTable)(this.Table));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int ID
            {
                get
                {
                    return ((int)(this[this.tableEventsLog.IDColumn]));
                }
                set
                {
                    this[this.tableEventsLog.IDColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Source
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableEventsLog.SourceColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Source\' in table \'EventsLog\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableEventsLog.SourceColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Type
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableEventsLog.TypeColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Type\' in table \'EventsLog\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableEventsLog.TypeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Description
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableEventsLog.DescriptionColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Description\' in table \'EventsLog\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableEventsLog.DescriptionColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string EventID
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableEventsLog.EventIDColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'EventID\' in table \'EventsLog\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableEventsLog.EventIDColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Date
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableEventsLog.DateColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Date\' in table \'EventsLog\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableEventsLog.DateColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Time
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableEventsLog.TimeColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Time\' in table \'EventsLog\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableEventsLog.TimeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsSourceNull()
            {
                return this.IsNull(this.tableEventsLog.SourceColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetSourceNull()
            {
                this[this.tableEventsLog.SourceColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsTypeNull()
            {
                return this.IsNull(this.tableEventsLog.TypeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetTypeNull()
            {
                this[this.tableEventsLog.TypeColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsDescriptionNull()
            {
                return this.IsNull(this.tableEventsLog.DescriptionColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetDescriptionNull()
            {
                this[this.tableEventsLog.DescriptionColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEventIDNull()
            {
                return this.IsNull(this.tableEventsLog.EventIDColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEventIDNull()
            {
                this[this.tableEventsLog.EventIDColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsDateNull()
            {
                return this.IsNull(this.tableEventsLog.DateColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetDateNull()
            {
                this[this.tableEventsLog.DateColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsTimeNull()
            {
                return this.IsNull(this.tableEventsLog.TimeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetTimeNull()
            {
                this[this.tableEventsLog.TimeColumn] = System.Convert.DBNull;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class SecurityDataBaseRow : System.Data.DataRow
        {

            private SecurityDataBaseDataTable tableSecurityDataBase;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal SecurityDataBaseRow(System.Data.DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableSecurityDataBase = ((SecurityDataBaseDataTable)(this.Table));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int ID
            {
                get
                {
                    return ((int)(this[this.tableSecurityDataBase.IDColumn]));
                }
                set
                {
                    this[this.tableSecurityDataBase.IDColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string UserFirstName
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.UserFirstNameColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'UserFirstName\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.UserFirstNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string UserLogin
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.UserLoginColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'UserLogin\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.UserLoginColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string UserPassword
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.UserPasswordColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'UserPassword\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.UserPasswordColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime CreationTime
            {
                get
                {
                    try
                    {
                        return ((System.DateTime)(this[this.tableSecurityDataBase.CreationTimeColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'CreationTime\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.CreationTimeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool EnabledAccountState
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableSecurityDataBase.EnabledAccountStateColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'EnabledAccountState\' in table \'SecurityDataBase\' is DBNull." +
                                "", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.EnabledAccountStateColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string UserMiddleName
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.UserMiddleNameColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'UserMiddleName\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.UserMiddleNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string UserLastName
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.UserLastNameColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'UserLastName\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.UserLastNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string ICQ
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.ICQColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'ICQ\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.ICQColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Company
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.CompanyColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'Company\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.CompanyColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string HomePhone
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.HomePhoneColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'HomePhone\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.HomePhoneColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string WorkPhone
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.WorkPhoneColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'WorkPhone\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.WorkPhoneColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string PrivateCellular
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.PrivateCellularColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'PrivateCellular\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.PrivateCellularColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string EMail
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.EMailColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'EMail\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.EMailColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string UserName
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableSecurityDataBase.UserNameColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'UserName\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.UserNameColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int AccountType
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableSecurityDataBase.AccountTypeColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'AccountType\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.AccountTypeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int PermissionsLevel
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableSecurityDataBase.PermissionsLevelColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'PermissionsLevel\' in table \'SecurityDataBase\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableSecurityDataBase.PermissionsLevelColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsUserFirstNameNull()
            {
                return this.IsNull(this.tableSecurityDataBase.UserFirstNameColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetUserFirstNameNull()
            {
                this[this.tableSecurityDataBase.UserFirstNameColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsUserLoginNull()
            {
                return this.IsNull(this.tableSecurityDataBase.UserLoginColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetUserLoginNull()
            {
                this[this.tableSecurityDataBase.UserLoginColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsUserPasswordNull()
            {
                return this.IsNull(this.tableSecurityDataBase.UserPasswordColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetUserPasswordNull()
            {
                this[this.tableSecurityDataBase.UserPasswordColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCreationTimeNull()
            {
                return this.IsNull(this.tableSecurityDataBase.CreationTimeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCreationTimeNull()
            {
                this[this.tableSecurityDataBase.CreationTimeColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEnabledAccountStateNull()
            {
                return this.IsNull(this.tableSecurityDataBase.EnabledAccountStateColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEnabledAccountStateNull()
            {
                this[this.tableSecurityDataBase.EnabledAccountStateColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsUserMiddleNameNull()
            {
                return this.IsNull(this.tableSecurityDataBase.UserMiddleNameColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetUserMiddleNameNull()
            {
                this[this.tableSecurityDataBase.UserMiddleNameColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsUserLastNameNull()
            {
                return this.IsNull(this.tableSecurityDataBase.UserLastNameColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetUserLastNameNull()
            {
                this[this.tableSecurityDataBase.UserLastNameColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsICQNull()
            {
                return this.IsNull(this.tableSecurityDataBase.ICQColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetICQNull()
            {
                this[this.tableSecurityDataBase.ICQColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCompanyNull()
            {
                return this.IsNull(this.tableSecurityDataBase.CompanyColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCompanyNull()
            {
                this[this.tableSecurityDataBase.CompanyColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsHomePhoneNull()
            {
                return this.IsNull(this.tableSecurityDataBase.HomePhoneColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetHomePhoneNull()
            {
                this[this.tableSecurityDataBase.HomePhoneColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsWorkPhoneNull()
            {
                return this.IsNull(this.tableSecurityDataBase.WorkPhoneColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetWorkPhoneNull()
            {
                this[this.tableSecurityDataBase.WorkPhoneColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsPrivateCellularNull()
            {
                return this.IsNull(this.tableSecurityDataBase.PrivateCellularColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetPrivateCellularNull()
            {
                this[this.tableSecurityDataBase.PrivateCellularColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEMailNull()
            {
                return this.IsNull(this.tableSecurityDataBase.EMailColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEMailNull()
            {
                this[this.tableSecurityDataBase.EMailColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsUserNameNull()
            {
                return this.IsNull(this.tableSecurityDataBase.UserNameColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetUserNameNull()
            {
                this[this.tableSecurityDataBase.UserNameColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsAccountTypeNull()
            {
                return this.IsNull(this.tableSecurityDataBase.AccountTypeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetAccountTypeNull()
            {
                this[this.tableSecurityDataBase.AccountTypeColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsPermissionsLevelNull()
            {
                return this.IsNull(this.tableSecurityDataBase.PermissionsLevelColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetPermissionsLevelNull()
            {
                this[this.tableSecurityDataBase.PermissionsLevelColumn] = System.Convert.DBNull;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class AccessRestrictionRulesRow : System.Data.DataRow
        {

            private AccessRestrictionRulesDataTable tableAccessRestrictionRules;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal AccessRestrictionRulesRow(System.Data.DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableAccessRestrictionRules = ((AccessRestrictionRulesDataTable)(this.Table));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int ID
            {
                get
                {
                    return ((int)(this[this.tableAccessRestrictionRules.IDColumn]));
                }
                set
                {
                    this[this.tableAccessRestrictionRules.IDColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string IPRangeStartValue
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableAccessRestrictionRules.IPRangeStartValueColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'IPRangeStartValue\' in table \'AccessRestrictionRules\' is DBN" +
                                "ull.", e);
                    }
                }
                set
                {
                    this[this.tableAccessRestrictionRules.IPRangeStartValueColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string IPRangeEndValue
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableAccessRestrictionRules.IPRangeEndValueColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'IPRangeEndValue\' in table \'AccessRestrictionRules\' is DBNul" +
                                "l.", e);
                    }
                }
                set
                {
                    this[this.tableAccessRestrictionRules.IPRangeEndValueColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string IPAddress
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableAccessRestrictionRules.IPAddressColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'IPAddress\' in table \'AccessRestrictionRules\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableAccessRestrictionRules.IPAddressColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string MACAddress
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableAccessRestrictionRules.MACAddressColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'MACAddress\' in table \'AccessRestrictionRules\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableAccessRestrictionRules.MACAddressColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int RuleType
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableAccessRestrictionRules.RuleTypeColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'RuleType\' in table \'AccessRestrictionRules\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableAccessRestrictionRules.RuleTypeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool ComplementaryUseMACAddress
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableAccessRestrictionRules.ComplementaryUseMACAddressColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'ComplementaryUseMACAddress\' in table \'AccessRestrictionRule" +
                                "s\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableAccessRestrictionRules.ComplementaryUseMACAddressColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime CreationTime
            {
                get
                {
                    try
                    {
                        return ((System.DateTime)(this[this.tableAccessRestrictionRules.CreationTimeColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'CreationTime\' in table \'AccessRestrictionRules\' is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableAccessRestrictionRules.CreationTimeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsRestrictionEnabled
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableAccessRestrictionRules.IsRestrictionEnabledColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'IsRestrictionEnabled\' in table \'AccessRestrictionRules\' is " +
                                "DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableAccessRestrictionRules.IsRestrictionEnabledColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsIPRangeStartValueNull()
            {
                return this.IsNull(this.tableAccessRestrictionRules.IPRangeStartValueColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetIPRangeStartValueNull()
            {
                this[this.tableAccessRestrictionRules.IPRangeStartValueColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsIPRangeEndValueNull()
            {
                return this.IsNull(this.tableAccessRestrictionRules.IPRangeEndValueColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetIPRangeEndValueNull()
            {
                this[this.tableAccessRestrictionRules.IPRangeEndValueColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsIPAddressNull()
            {
                return this.IsNull(this.tableAccessRestrictionRules.IPAddressColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetIPAddressNull()
            {
                this[this.tableAccessRestrictionRules.IPAddressColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMACAddressNull()
            {
                return this.IsNull(this.tableAccessRestrictionRules.MACAddressColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMACAddressNull()
            {
                this[this.tableAccessRestrictionRules.MACAddressColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsRuleTypeNull()
            {
                return this.IsNull(this.tableAccessRestrictionRules.RuleTypeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetRuleTypeNull()
            {
                this[this.tableAccessRestrictionRules.RuleTypeColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsComplementaryUseMACAddressNull()
            {
                return this.IsNull(this.tableAccessRestrictionRules.ComplementaryUseMACAddressColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetComplementaryUseMACAddressNull()
            {
                this[this.tableAccessRestrictionRules.ComplementaryUseMACAddressColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCreationTimeNull()
            {
                return this.IsNull(this.tableAccessRestrictionRules.CreationTimeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCreationTimeNull()
            {
                this[this.tableAccessRestrictionRules.CreationTimeColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsIsRestrictionEnabledNull()
            {
                return this.IsNull(this.tableAccessRestrictionRules.IsRestrictionEnabledColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetIsRestrictionEnabledNull()
            {
                this[this.tableAccessRestrictionRules.IsRestrictionEnabledColumn] = System.Convert.DBNull;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class CommonSecuritySettingsRow : System.Data.DataRow
        {

            private CommonSecuritySettingsDataTable tableCommonSecuritySettings;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal CommonSecuritySettingsRow(System.Data.DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCommonSecuritySettings = ((CommonSecuritySettingsDataTable)(this.Table));
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int MinRSAKeySize
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCommonSecuritySettings.MinRSAKeySizeColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'MinRSAKeySize\' in table \'CommonSecuritySettings\' is DBNull." +
                                "", e);
                    }
                }
                set
                {
                    this[this.tableCommonSecuritySettings.MinRSAKeySizeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int MaxRSAKeySize
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCommonSecuritySettings.MaxRSAKeySizeColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'MaxRSAKeySize\' in table \'CommonSecuritySettings\' is DBNull." +
                                "", e);
                    }
                }
                set
                {
                    this[this.tableCommonSecuritySettings.MaxRSAKeySizeColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int MaxConnectionPerAccount
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCommonSecuritySettings.MaxConnectionPerAccountColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'MaxConnectionPerAccount\' in table \'CommonSecuritySettings\' " +
                                "is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableCommonSecuritySettings.MaxConnectionPerAccountColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool EnableAccessRestrictions
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableCommonSecuritySettings.EnableAccessRestrictionsColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'EnableAccessRestrictions\' in table \'CommonSecuritySettings\'" +
                                " is DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableCommonSecuritySettings.EnableAccessRestrictionsColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int MaxConnections
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCommonSecuritySettings.MaxConnectionsColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'MaxConnections\' in table \'CommonSecuritySettings\' is DBNull" +
                                ".", e);
                    }
                }
                set
                {
                    this[this.tableCommonSecuritySettings.MaxConnectionsColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool AllowWindowsAccounts
            {
                get
                {
                    try
                    {
                        return ((bool)(this[this.tableCommonSecuritySettings.AllowWindowsAccountsColumn]));
                    }
                    catch (System.InvalidCastException e)
                    {
                        throw new System.Data.StrongTypingException("The value for column \'AllowWindowsAccounts\' in table \'CommonSecuritySettings\' is " +
                                "DBNull.", e);
                    }
                }
                set
                {
                    this[this.tableCommonSecuritySettings.AllowWindowsAccountsColumn] = value;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMinRSAKeySizeNull()
            {
                return this.IsNull(this.tableCommonSecuritySettings.MinRSAKeySizeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMinRSAKeySizeNull()
            {
                this[this.tableCommonSecuritySettings.MinRSAKeySizeColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMaxRSAKeySizeNull()
            {
                return this.IsNull(this.tableCommonSecuritySettings.MaxRSAKeySizeColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMaxRSAKeySizeNull()
            {
                this[this.tableCommonSecuritySettings.MaxRSAKeySizeColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMaxConnectionPerAccountNull()
            {
                return this.IsNull(this.tableCommonSecuritySettings.MaxConnectionPerAccountColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMaxConnectionPerAccountNull()
            {
                this[this.tableCommonSecuritySettings.MaxConnectionPerAccountColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEnableAccessRestrictionsNull()
            {
                return this.IsNull(this.tableCommonSecuritySettings.EnableAccessRestrictionsColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEnableAccessRestrictionsNull()
            {
                this[this.tableCommonSecuritySettings.EnableAccessRestrictionsColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMaxConnectionsNull()
            {
                return this.IsNull(this.tableCommonSecuritySettings.MaxConnectionsColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMaxConnectionsNull()
            {
                this[this.tableCommonSecuritySettings.MaxConnectionsColumn] = System.Convert.DBNull;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsAllowWindowsAccountsNull()
            {
                return this.IsNull(this.tableCommonSecuritySettings.AllowWindowsAccountsColumn);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetAllowWindowsAccountsNull()
            {
                this[this.tableCommonSecuritySettings.AllowWindowsAccountsColumn] = System.Convert.DBNull;
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class MainSettingsRowChangeEvent : System.EventArgs
        {

            private MainSettingsRow eventRow;

            private System.Data.DataRowAction eventAction;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public MainSettingsRowChangeEvent(MainSettingsRow row, System.Data.DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public MainSettingsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class EventsLogRowChangeEvent : System.EventArgs
        {

            private EventsLogRow eventRow;

            private System.Data.DataRowAction eventAction;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public EventsLogRowChangeEvent(EventsLogRow row, System.Data.DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public EventsLogRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SecurityDataBaseRowChangeEvent : System.EventArgs
        {

            private SecurityDataBaseRow eventRow;

            private System.Data.DataRowAction eventAction;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SecurityDataBaseRowChangeEvent(SecurityDataBaseRow row, System.Data.DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SecurityDataBaseRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class AccessRestrictionRulesRowChangeEvent : System.EventArgs
        {

            private AccessRestrictionRulesRow eventRow;

            private System.Data.DataRowAction eventAction;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public AccessRestrictionRulesRowChangeEvent(AccessRestrictionRulesRow row, System.Data.DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public AccessRestrictionRulesRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class CommonSecuritySettingsRowChangeEvent : System.EventArgs
        {

            private CommonSecuritySettingsRow eventRow;

            private System.Data.DataRowAction eventAction;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public CommonSecuritySettingsRowChangeEvent(CommonSecuritySettingsRow row, System.Data.DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public CommonSecuritySettingsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591

*/