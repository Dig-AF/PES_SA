﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace EAWS.Core.SilverBullet
{
    public static class PES_SA
    {

        //Translation Data Structures

        static string[][] Element_Lookup = new string[][] { 
                            new string[] { "Activity", "Activity (DM2)", "IndividualType", "1154", "1326", "default" }, 
                            new string[] { "Activity", "Operational Activity", "IndividualType", "", "", "extra" },

                            new string[] { "Activity", "BPMN Event", "IndividualType", "", "", "extra" },
                            new string[] { "Activity", "BPMN Process", "IndividualType", "", "", "extra" },

                            new string[] { "Activity", "Data Store (DM2x)", "IndividualType", "", "", "extra" },
                            new string[] { "Activity", "Project Milestone (DM2x)", "IndividualType", "1441", "1450", "extra" },
                            new string[] { "Activity", "System Milestone (DM2x)", "IndividualType", "1516", "1507", "extra" },
                            new string[] { "Capability", "Capability (DM2)", "IndividualType", "1155", "1327", "default" },
                            new string[] { "Performer", "Performer (DM2)", "IndividualType", "1178", "1367", "default" },

                            new string[] { "Performer", "Participant", "IndividualType", "779", "610", "extra" },

                            new string[] { "Activity", "System Function (DM2x)", "IndividualType", "1207", "1384", "extra" },
                            new string[] { "Activity", "Service Function (DM2x)", "IndividualType", "1207", "1395", "extra" },
                            new string[] { "Activity", "Event (DM2x)", "IndividualType", "1207", "1463", "extra" },
                            new string[] { "Service", "Service (DM2)", "IndividualType","1160", "1376", "default" },
                            new string[] { "Resource", "Resource (DM2)", "IndividualType","", "", "default" },
                            new string[] { "System", "System (DM2)", "IndividualType","1188", "1377", "default" },
                            new string[] { "System", "Data Store (DM2x)", "IndividualType","1214", "1385", "extra" },
                            new string[] { "Materiel", "Materiel (DM2)", "IndividualType","1177", "1366", "default" },
                            new string[] { "Information", "Information (DM2)", "IndividualType","1176", "1365", "default" },
                            new string[] { "PersonRole", "Person (DM2)", "IndividualType","1186", "1375", "default" },
                            new string[] { "DomainInformation", "DomainInformation (DM2)", "IndividualType","", "1371", "default" },

                            new string[] { "Data", "Table", "IndividualType","", "1370", "extra" },
                            new string[] { "Data", "Column", "IndividualType","", "1370", "extra" },
                            new string[] { "Data", "Index", "IndividualType","", "1370", "extra" },
                            new string[] { "Data", "Physical Foreign Key Component", "IndividualType","", "1370", "extra" },
                            new string[] { "Data", "Logical Foreign Key Component", "IndividualType","", "1370", "extra" },

                            new string[] { "Data", "Data (DM2)", "IndividualType","", "1370", "extra" },
                            new string[] { "Data", "Entity", "IndividualType","30", "15", "default" },
                            new string[] { "Data", "Attribute", "IndividualType","30", "105", "extra" },
                            new string[] { "Data", "Data Element", "IndividualType","30", "5", "extra" },
                            new string[] { "Data", "Access Path", "IndividualType","21", "21", "extra" },
                            new string[] { "Performer", "ServiceInterface (DM2)", "IndividualType","", "", "extra" },
                            new string[] { "Performer", "Interface (Port) (DM2)", "IndividualType","", "", "extra" },
                            new string[] { "OrganizationType", "Organization (DM2)", "IndividualType","1185", "1374", "default" },
                            new string[] { "Condition", "Condition (Environmental) (DM2)", "IndividualType","1156", "1328", "default" },
                            new string[] { "Location", "Location (DM2)", "IndividualType","1161", "", "default" },
                            new string[] { "RegionOfCountry", "RegionOfCountry (DM2)", "IndividualType","1357", "1357", "default" },
                            new string[] { "Country", "Country (DM2)", "IndividualType","1358", "1358", "default" },
                            new string[] { "Rule", "Rule (DM2)", "IndividualType","1173", "1362", "default" },

                            //new string[] { "Rule", "Constraint", "IndividualType","1173", "1362", "extra" },

                            new string[] { "IndividualType", "IndividualType", "IndividualType","", "", "default" },
                            new string[] { "ArchitecturalDescription", "ArchitecturalDescription (DM2)", "IndividualType","1179", "1368","default" },
                            new string[] { "ServiceDescription", "ServiceDescription (DM2)", "IndividualType","", "1369","extra" },
                            new string[] { "ProjectType", "Project (DM2)", "IndividualType","1159", "1348","default" },
                            new string[] { "Vision", "Vision (DM2)", "IndividualType","1172", "1361","default" },
                            new string[] { "Guidance", "Guidance (DM2)", "IndividualType","1157", "1329","default" },
                            new string[] { "Facility", "Facility (DM2)", "IndividualType","", "1353","default" },
                            new string[] { "RealProperty", "RealProperty (DM2)", "IndividualType","", "1352","default" },
                            new string[] { "Site", "Site (DM2)", "IndividualType","", "1354","default" },
                            };

        static string[][] SA_Element_View_Lookup = new string[][] { 
                            new string[] { "AV-01 Overview and Summary (DM2)", "RealProperty (DM2)", "Location (DM2)", "1161" },
                            new string[] { "AV-01 Overview and Summary (DM2)", "Facility (DM2)", "Location (DM2)", "1161" },
                            new string[] { "OV-02 Operational Resource Flow (DM2)", "Organization (DM2)", "Resource (DM2)", "1160" },
                            new string[] { "OV-02 Operational Resource Flow (DM2)", "Person (DM2)", "Performer (DM2)", "1178" },

                            };

        //static string[][] RSA_Element_Lookup = new string[][] { 
        //                    new string[] { "Activity", "OperationalNodeSpecification", "IndividualType", "", "", "default" },
        //                    new string[] { "Capability", "Capability", "IndividualType", "", "", "default" },
        //                    new string[] { "System", "System", "IndividualType", "", "", "default" },

        //                    };

        //static string[][] Tuple_Lookup = new string[][] { 
        //                    };

        static string[][] Tuple_Type_Lookup = new string[][] { 
                            new string[] { "WholePartType", "Data Element", "WholePartType", "1", "Data", "Data" },
                            new string[] { "WholePartType", "Table Name", "WholePartType", "2", "Attribute", "Attribute" },
                            
                            new string[] { "WholePartType", "Foreign Keys and Roles", "WholePartType", "1", "Attribute", "Attribute" },
                            new string[] { "WholePartType", "Constraint Name", "WholePartType", "2", "Attribute", "Attribute" },

                            new string[] { "WholePartType", "Primary Index Name", "WholePartType", "1", "Element", "Element" },
                            //new string[] { "WholePartType", "Primary Key Name", "WholePartType", "2", "Element", "Element" },
                            new string[] { "WholePartType", "Entity Name", "WholePartType", "2", "Attribute", "Attribute" },
                            new string[] { "WholePartType", "activityParentOfActivity", "WholePartType", "1", "Activity (DM2)", "Activity" },
                            new string[] { "WholePartType", "activityPartOfActivity", "WholePartType", "2", "Activity (DM2)", "Activity" },
                            new string[] { "WholePartType", "Parent Of Capability", "WholePartType", "1", "Capability (DM2)", "Capability" },
                            new string[] { "WholePartType", "Parent Capability", "WholePartType", "2", "Capability (DM2)", "Capability" },
                            new string[] { "WholePartType", "Parent of Function", "WholePartType", "1", "Activity (DM2)", "Activity" },
                            new string[] { "WholePartType", "Part of Function", "WholePartType", "2", "Activity (DM2)", "Activity" },
                            new string[] { "WholePartType", "Parent Of Service", "WholePartType", "1", "Service (DM2)", "Service" },
                            new string[] { "WholePartType", "Part of Service", "WholePartType", "2", "Service (DM2)", "Service" },
                            new string[] { "WholePartType", "Parent of System", "WholePartType", "1", "System (DM2)", "System" }, 
                            new string[] { "WholePartType", "Part of System", "WholePartType", "2", "System (DM2)", "System" }, 
                            new string[] { "WholePartType", "PerformerMembers", "WholePartType", "1", "Organization (DM2)", "OrganizationType" },
                            new string[] { "WholePartType", "MemberOfOrganizations", "WholePartType", "2", "Organization (DM2)", "OrganizationType" },
                            new string[] { "WholePartType", "personPartOfPerformer", "WholePartType", "1", "Performer (DM2)", "Performer" },
                            new string[] { "WholePartType", "personPartOfPerformer", "WholePartType", "2", "Person (DM2)", "PersonRole" }, 
                            new string[] { "WholePartType", "portPartOfPerformer", "WholePartType", "5", "System (DM2)", "System" },
                            new string[] { "WholePartType", "portPartOfPerformer", "WholePartType", "4", "Interface (Port) (DM2)", "Performer" },
                            new string[] { "activityPartOfProjectType", "activityPartOfProjectType", "WholePartType", "5", "Project (DM2)", "ProjectType" },
                            new string[] { "activityPartOfProjectType", "activityPartOfProjectType", "WholePartType", "4", "Activity (DM2)", "Activity" },
                            new string[] { "WholePartType", "interfacePartOfService", "WholePartType", "5", "Service (DM2)", "Service" },
                            new string[] { "WholePartType", "interfacePartOfService", "WholePartType", "4", "ServiceInterface (DM2)", "Performer" },
                            //new string[] { "activityPartOfProjectType", "Milestones", "WholePartType", "1", "Activity (DM2)", "Activity" },
                            //new string[] { "activityPartOfProjectType", "Project", "WholePartType", "2", "Project (DM2)", "ProjectType" },
                            new string[] { "SupportedBy", "SupportedBy", "SupportedBy", "3", "Organization (DM2)", "OrganizationType" },
                            new string[] { "ruleConstrainsActivity", "ruleConstrainsActivity", "CoupleType", "2", "Activity (DM2)", "Activity" },
                            };

        //static string[][] SA_Element_Lookup = new string[][] {
        //                    new string[] { "Needline", "Need Line (DM2rx)", "CoupleType","1244", "1402","default" },
        //                    new string[] { "SysRF", "System Resource Flow (DM2rx)", "CoupleType","1245", "1403","default" },
        //                    new string[] { "PRF", "Physical Resource Flow (DM2rx)", "CoupleType","1475", "1462","default" },
        //                    new string[] { "SvcRF", "Service Resource Flow (DM2rx)", "CoupleType","1236", "1394","default" },
        //                    new string[] { "SDF", "System Data Flow (DM2rx)", "CoupleType","1215", "1386","default" },
        //                    new string[] { "SvcDF", "Service Data Flow (DM2rx)", "CoupleType","1239", "1396","default" },
        //                    new string[] { "CapabilityDependency", "Capability Dependency (DM2rx)", "CoupleType","1433", "1449","default" },
        //                    new string[] { "ARO", "ActivityResourceOverlap (DM2r)", "CoupleType","1208", "1383","default" },
        //                    };

        static string[][] View_Lookup = new string[][] {  
                            new string[] {"AV-1", "AV-01 Overview and Summary (DM2)", "289", "default"}, 
                            new string[] {"CV-1", "CV-01 Vision (DM2)", "290", "default"},
                            new string[] {"CV-2", "CV-02 Capability Taxonomy (DM2)", "305", "default"}, //1st
                            new string[] {"CV-4", "CV-04 Capability Dependencies (DM2)", "341", "default"},
                            new string[] {"DIV-2", "DIV-02 Logical Data Model (Entity Relation) (DM2)", "4", "default"},
                            
                            new string[] {"DIV-3", "DIV-03 Physical Data Model (DM2)", "26", "default"},
                            new string[] {"OV-1", "OV-01 High Level Operational Concept (DM2)", "280", "default"}, //1st
                            new string[] {"OV-2", "OV-02 Operational Resource Flow (DM2)", "281", "default"},
                            
                            new string[] {"OV-4", "OV-04 Organizational Relationships (DM2)", "283", "default"},
                            new string[] {"OV-5a", "OV-05a Operational Activity Decomposition (DM2)", "284", "default"}, //1st
                            new string[] {"OV-5b", "OV-05b Operational Activity Model (DM2)", "285", "default"},
                            new string[] {"OV-6a", "OV-06a Operational Rules Model (DM2)", "286", "default"},
                            new string[] {"OV-6b", "OV-06b State Transition (DM2)", "339", "default"},
                            new string[] {"OV-6c", "OV-06c Performers Event-Trace (DM2)", "340", "extra"},  
                            
                            new string[] {"OV-6c", "OV-06c Activities Event-Trace (DM2)", "288", "default"},
                            new string[] {"OV-6c", "OV-06c/SV-11c/SvcV-11c BPMN Event Trace Description (DM2x)", "142", "default"},
                            
                            new string[] {"PV-2", "PV-02 Project Timelines (DM2)", "346", "default"},
                            new string[] {"SV-1", "SV-01 Systems Interface Description (DM2)", "309", "default"},
                            
                            new string[] {"SV-2", "SV-02 Systems Resource Flow Description (DM2)", "310", "default"},
                            
                            new string[] {"SV-4", "SV-04 Systems Functionality Description (DM2)", "311", "default"},
                            
                            new string[] {"SV-8", "SV-08 Systems Evolution Description (DM2)", "365", "default"},
                            
                            new string[] {"SV-10c", "SV-10c Performer-Role Event-Trace (DM2x)", "134", "default"},

                            new string[] {"SvcV-1", "SvcV-01 Services Context Description (DM2)", "312", "default"},
                            new string[] {"SvcV-2", "SvcV-02 Services Resource Flow Description (DM2)", "313", "default"},
                            new string[] {"SvcV-4", "SvcV-04 Services Functionality Description (DM2)", "314", "default"},
                            
                            
                            };

        static string[][] Not_Processed_View_Lookup = new string[][] {  
                            new string[] {"SV-1", "SV-01 Systems Interface Description Alternative (DM2)", "291", "default"},  
                            new string[] {"SV-2", "SV-02 Systems Resource Flow Description Alternative (DM2)", "292", "default"},
                            new string[] {"SV-4", "SV-04 Systems Functionality Decomposition (DM2)", "300", "extra"},
                            new string[] {"SV-4", "SV-04 Systems Functionality Description Alternative (DM2)", "293", "extra"},
                            new string[] {"SV-10c", "SV-10c Systems Event-Trace (DM2)", "335", "default"},
                            new string[] {"DIV-2", "DIV-02 Logical Data Model (IDEF1X) (DM2)", "23", "default"},
                            new string[] {"OV-6b", "OV-06b State Transition Alternative (DM2)", "287", "extra"}, 
                            new string[] {"OV-2", "OV-02 Operational Resource Flow Alternative (DM2)", "282", "extra"},
                            new string[] {"PV-1", "PV-01 Project Portfolio Relationships (DM2)", "342", "default"},
                            new string[] {"PV-1", "PV-01 Project Portfolio Relationships At Time (DM2)", "343", "extra"},
                            new string[] {"SV-10b", "SV-10b Systems State Transition Description (DM2)", "344", "default"},
                            new string[] {"SvcV-10b", "SvcV-10b Services State Transition Description (DM2)", "345", "default"},
                            new string[] {"SvcV-10c", "SvcV-10c Performer-Role Event-Trace (DM2x)", "138", "default"},
                            new string[] {"SvcV-1", "SvcV-01 Services Context Description Alternative (DM2)", "301", "default"},
                            new string[] {"SvcV-2", "SvcV-02 Services Resource Flow Description Alternative (DM2)", "302", "default"},
                            new string[] {"SvcV-4", "SvcV-04 Services Functionality Description Alternative (DM2)", "303", "default"},
        };

        static string[][] Mandatory_Lookup = new string[][] { 
                            new string[] {"Capability", "CV-2"},
                            new string[] {"ArchitecturalDescription", "OV-1"},
                            new string[] {"Activity", "OV-5a"},
                            new string[] {"Activity", "OV-2"},
                            new string[] {"activityPerformedByPerformer", "OV-2"},
                            new string[] {"activityProducesResource", "OV-2"},
                            new string[] {"activityConsumesResource", "OV-2"},
                            new string[] {"Activity", "OV-3"},
                            new string[] {"activityPerformedByPerformer", "OV-3"},
                            new string[] {"activityProducesResource", "OV-3"},
                            new string[] {"activityConsumesResource", "OV-3"},
                            new string[] {"Activity", "SV-6"},
                            new string[] {"activityPerformedByPerformer", "SV-6"},
                            new string[] {"activityProducesResource", "SV-6"},
                            new string[] {"activityConsumesResource", "SV-6"},
                            new string[] {"System", "SV-6"},
                            new string[] {"Data", "SV-6"},

                            new string[] {"Activity", "SvcV-6"},
                            new string[] {"activityPerformedByPerformer", "SvcV-6"},
                            new string[] {"activityProducesResource", "SvcV-6"},
                            new string[] {"activityConsumesResource", "SvcV-6"},
                            new string[] {"Service", "SvcV-6"},
                            new string[] {"Data", "SvcV-6"},

                            new string[] {"Activity", "OV-5b"},
                            new string[] {"activityProducesResource", "OV-5b"},
                            new string[] {"activityConsumesResource", "OV-5b"},
                            new string[] {"Activity", "OV-6b"},
                            new string[] {"activityProducesResource", "OV-6b"},
                            new string[] {"activityConsumesResource", "OV-6b"},
                            new string[] {"Activity", "OV-6a"},
                            new string[] {"Activity", "AV-1"},
                            new string[] {"activityPartOfProjectType", "AV-1"},
                            new string[] {"ArchitecturalDescription", "AV-1"},
                            new string[] {"ProjectType", "AV-1"},
                            new string[] {"Capability", "CV-1"},
                            new string[] {"desiredResourceStateOfCapability", "CV-1"},
                            new string[] {"desireMeasure", "CV-1"},
                            new string[] {"effectMeasure", "CV-1"},
                            new string[] {"MeasureOfDesire", "CV-1"},
                            new string[] {"MeasureOfEffect", "CV-1"},
                            new string[] {"visionRealizedByDesiredResourceState", "CV-1"},
                            new string[] {"Vision", "CV-1"},
                            new string[] {"Capability", "CV-4"},
                            new string[] {"desiredResourceStateOfCapability", "CV-4"},
                            new string[] {"Activity", "OV-6c"},
                            new string[] {"Activity", "SV-1"},
                            new string[] {"activityPerformedByPerformer", "SV-1"},
                            new string[] {"activityProducesResource", "SV-1"},
                            new string[] {"activityConsumesResource", "SV-1"},
                            new string[] {"System", "SV-1"},
                            new string[] {"Activity", "SV-10b"},
                            new string[] {"activityPerformedByPerformer", "SV-10b"},
                            new string[] {"activityProducesResource", "SV-10b"},
                            new string[] {"activityConsumesResource", "SV-10b"},
                            new string[] {"System", "SV-10b"},
                            new string[] {"Activity", "SV-10c"},
                            new string[] {"activityPerformedByPerformer", "SV-10c"},
                            new string[] {"activityProducesResource", "SV-10c"},
                            new string[] {"activityConsumesResource", "SV-10c"},
                            new string[] {"System", "SV-10c"},
                            new string[] {"Activity", "SvcV-1"},
                            new string[] {"activityPerformedByPerformer", "SvcV-1"},
                            new string[] {"activityProducesResource", "SvcV-1"},
                            new string[] {"activityConsumesResource", "SvcV-1"},
                            new string[] {"Service", "SvcV-1"},
                            new string[] {"Activity", "SvcV-10b"},
                            new string[] {"activityPerformedByPerformer", "SvcV-10b"},
                            new string[] {"activityProducesResource", "SvcV-10b"},
                            new string[] {"activityConsumesResource", "SvcV-10b"},
                            new string[] {"Service", "SvcV-10b"},
                            new string[] {"Activity", "SvcV-10c"},
                            new string[] {"activityPerformedByPerformer", "SvcV-10c"},
                            new string[] {"activityProducesResource", "SvcV-10c"},
                            new string[] {"activityConsumesResource", "SvcV-10c"},
                            new string[] {"Service", "SvcV-10c"},
                            new string[] {"Activity", "SV-4"},
                            new string[] {"activityPerformedByPerformer", "SV-4"},
                            new string[] {"activityProducesResource", "SV-4"},
                            new string[] {"activityConsumesResource", "SV-4"},
                            new string[] {"Data", "SV-4"},
                            new string[] {"System", "SV-4"},
                            new string[] {"Activity", "SvcV-4"},
                            new string[] {"activityPerformedByPerformer", "SvcV-4"},
                            new string[] {"activityProducesResource", "SvcV-4"},
                            new string[] {"activityConsumesResource", "SvcV-4"},
                            new string[] {"Data", "SvcV-4"},
                            new string[] {"Service", "SvcV-4"},
                            new string[] {"Activity", "SV-2"},
                            new string[] {"activityPerformedByPerformer", "SV-2"},
                            new string[] {"activityProducesResource", "SV-2"},
                            new string[] {"activityConsumesResource", "SV-2"},
                            new string[] {"System", "SV-2"},
                            new string[] {"System", "SV-8"},
                            new string[] {"Activity", "SvcV-2"},
                            new string[] {"activityPerformedByPerformer", "SvcV-2"},
                            new string[] {"activityProducesResource", "SvcV-2"},
                            new string[] {"activityConsumesResource", "SvcV-2"},
                            new string[] {"Service", "SvcV-2"},
                            new string[] {"Activity", "PV-1"},
                            new string[] {"activityPartOfProjectType", "PV-1"},
                            new string[] {"ProjectType", "PV-1"},
                            new string[] {"activityPerformedByPerformer", "PV-1"},
                            new string[] {"OrganizationType", "PV-1"},
                            new string[] {"Activity", "PV-2"},
                            new string[] {"activityPartOfProjectType", "PV-2"},
                            new string[] {"ProjectType", "PV-2"},
                            new string[] {"Data", "DIV-2"},
                            new string[] {"Data", "DIV-3"},
                            new string[] {"DataType", "DIV-3"},
                            };

        static string[][] Optional_Lookup = new string[][] { 
                            new string[] {"Activity", "CV-1"},
                            new string[] {"Condition", "CV-1"},
                            new string[] {"DomainInformation", "CV-1"},
                            new string[] {"Information", "CV-1"},
                            new string[] {"Location", "CV-1"},
                            new string[] {"Performer", "CV-1"},
                            new string[] {"PersonRole", "CV-1"},
                            new string[] {"Resource", "CV-1"},
                            new string[] {"Rule", "CV-1"}, 
                            new string[] {"System", "CV-1"},
                            new string[] {"Service", "CV-1"},
                            new string[] {"ServiceDescription", "CV-1"},
                            new string[] {"superSubtype", "CV-1"}, 
                            new string[] {"WholePartType", "CV-1"},
                            new string[] {"activityPartOfCapability", "CV-1"}, 
                            new string[] {"Activity", "CV-2"},
                            new string[] {"Condition", "CV-2"},
                            new string[] {"DomainInformation", "CV-2"},
                            new string[] {"Information", "CV-2"},
                            new string[] {"Location", "CV-2"},
                            new string[] {"Performer", "CV-2"},
                            new string[] {"PersonRole", "CV-2"},
                            new string[] {"Resource", "CV-2"},
                            new string[] {"Rule", "CV-2"}, 
                            new string[] {"System", "CV-2"},
                            new string[] {"Service", "CV-2"},
                            new string[] {"superSubtype", "CV-2"}, 
                            new string[] {"WholePartType", "CV-2"}, 
                            new string[] {"BeforeAfterType", "CV-2"},
                            new string[] {"Activity", "CV-4"},
                            new string[] {"activityPerformedByPerformer", "CV-4"},
                            new string[] {"activityProducesResource", "CV-4"},
                            new string[] {"activityConsumesResource", "CV-4"},
                            new string[] {"BeforeAfterType", "CV-4"},
                            new string[] {"Condition", "CV-4"},
                            new string[] {"DomainInformation", "CV-4"},
                            new string[] {"Information", "CV-4"},
                            new string[] {"Location", "CV-4"},
                            new string[] {"Performer", "CV-4"},
                            new string[] {"PersonRole", "CV-4"},
                            new string[] {"OrganizationType", "CV-4"},
                            new string[] {"Resource", "CV-4"},
                            new string[] {"Rule", "CV-4"}, 
                            new string[] {"System", "CV-4"},
                            new string[] {"Service", "CV-4"},
                            new string[] {"ServiceDescription", "CV-4"},
                            new string[] {"superSubtype", "CV-4"}, 
                            new string[] {"WholePartType", "CV-4"},
                            new string[] {"activityPartOfCapability", "CV-4"}, 
                            new string[] {"Information", "OV-1"},
                            new string[] {"Location", "OV-1"},
                            new string[] {"Performer", "OV-1"},
                            new string[] {"Resource", "OV-1"},
                            new string[] {"Rule", "OV-1"}, 
                            new string[] {"superSubtype", "OV-1"}, 
                            new string[] {"WholePartType", "OV-1"},
                            new string[] {"representationSchemeInstance", "OV-1"},
                            //new string[] {"OverlapType", "OV-1"},
                            new string[] {"Condition", "OV-2"},
                            new string[] {"Information", "OV-2"},
                            new string[] {"Location", "OV-2"},
                            new string[] {"OrganizationType", "OV-2"},
                            new string[] {"Performer", "OV-2"},
                            new string[] {"PersonRole", "OV-2"},
                            new string[] {"Resource", "OV-2"},
                            new string[] {"Rule", "OV-2"}, 
                            new string[] {"superSubtype", "OV-2"}, 
                            new string[] {"WholePartType", "OV-2"},
                            new string[] {"OverlapType", "OV-2"},
                            new string[] {"Condition", "OV-3"},
                            new string[] {"Information", "OV-3"},
                            new string[] {"Location", "OV-3"},
                            new string[] {"OrganizationType", "OV-3"},
                            new string[] {"Performer", "OV-3"},
                            new string[] {"PersonRole", "OV-3"},
                            new string[] {"Resource", "OV-3"},
                            new string[] {"Rule", "OV-3"}, 
                            new string[] {"superSubtype", "OV-3"}, 
                            new string[] {"WholePartType", "OV-3"},
                            //new string[] {"Condition", "SV-6"},
                            //new string[] {"Information", "SV-6"},
                            //new string[] {"Location", "SV-6"},
                            //new string[] {"OrganizationType", "SV-6"},
                            //new string[] {"Performer", "SV-6"},
                            //new string[] {"PersonRole", "SV-6"},
                            //new string[] {"Resource", "SV-6"},
                            //new string[] {"Rule", "SV-6"}, 
                            //new string[] {"superSubtype", "SV-6"}, 
                            //new string[] {"WholePartType", "SV-6"},
                            new string[] {"Information", "OV-4"},
                            new string[] {"Location", "OV-4"},
                            new string[] {"OrganizationType", "OV-4"},
                            new string[] {"Performer", "OV-4"},
                            new string[] {"PersonRole", "OV-4"},
                            new string[] {"Resource", "OV-4"},
                            new string[] {"Rule", "OV-4"}, 
                            new string[] {"superSubtype", "OV-4"}, 
                            new string[] {"WholePartType", "OV-4"},
                            //new string[] {"OverlapType", "OV-4"},
                            new string[] {"Condition", "OV-5a"},
                            new string[] {"Information", "OV-5a"},
                            new string[] {"Location", "OV-5a"},
                            new string[] {"Performer", "OV-5a"},
                            new string[] {"Resource", "OV-5a"},
                            new string[] {"Rule", "OV-5a"}, 
                            new string[] {"superSubtype", "OV-5a"}, 
                            new string[] {"WholePartType", "OV-5a"}, 
                            new string[] {"Condition", "OV-5b"},
                            new string[] {"Data", "OV-5b"},
                            new string[] {"Information", "OV-5b"},
                            new string[] {"Location", "OV-5b"},
                            new string[] {"OrganizationType", "OV-5b"},
                            new string[] {"Performer", "OV-5b"},
                            new string[] {"PersonRole", "OV-5b"},
                            new string[] {"Resource", "OV-5b"},
                            new string[] {"Rule", "OV-5b"}, 
                            new string[] {"superSubtype", "OV-5b"}, 
                            new string[] {"WholePartType", "OV-5b"},
                            new string[] {"OverlapType", "OV-5b"},
                            new string[] {"activityPerformedByPerformer", "OV-5b"},
                            new string[] {"Condition", "OV-6b"},
                            new string[] {"Information", "OV-6b"},
                            new string[] {"Location", "OV-6b"},
                            new string[] {"OrganizationType", "OV-6b"},
                            new string[] {"Performer", "OV-6b"},
                            new string[] {"PersonRole", "OV-6b"},
                            new string[] {"Resource", "OV-6b"},
                            new string[] {"Rule", "OV-6b"}, 
                            new string[] {"superSubtype", "OV-6b"}, 
                            new string[] {"WholePartType", "OV-6b"},
                            new string[] {"activityPerformedByPerformer", "OV-6b"},
                            new string[] {"BeforeAfterType", "OV-6b"},
                            new string[] {"Condition", "OV-6c"},
                            new string[] {"Information", "OV-6c"},
                            new string[] {"Location", "OV-6c"},
                            new string[] {"OrganizationType", "OV-6c"},
                            new string[] {"Performer", "OV-6c"},
                            new string[] {"PersonRole", "OV-6c"},
                            new string[] {"Resource", "OV-6c"},
                            new string[] {"Rule", "OV-6c"}, 
                            new string[] {"superSubtype", "OV-6c"}, 
                            new string[] {"WholePartType", "OV-6c"},
                            new string[] {"activityPerformedByPerformer", "OV-6c"},
                            new string[] {"BeforeAfterType", "OV-6c"},
                            new string[] {"Condition", "OV-6a"},
                            new string[] {"Information", "OV-6a"},
                            new string[] {"Location", "OV-6a"},
                            new string[] {"OrganizationType", "OV-6a"},
                            new string[] {"Performer", "OV-6a"},
                            new string[] {"PersonRole", "OV-6a"},
                            new string[] {"Resource", "OV-6a"},
                            new string[] {"Rule", "OV-6a"}, 
                            new string[] {"superSubtype", "OV-6a"}, 
                            new string[] {"WholePartType", "OV-6a"},
                            new string[] {"ruleConstrainsActivity", "OV-6a"},
                            new string[] {"activityPerformedByPerformer", "OV-6a"},
                            new string[] {"Condition", "AV-1"},
                            new string[] {"Facility", "AV-1"},
                            new string[] {"Guidance", "AV-1"},
                            new string[] {"Information", "AV-1"},
                            new string[] {"Location", "AV-1"},
                            new string[] {"OrganizationType", "AV-1"},
                            new string[] {"Performer", "AV-1"},
                            new string[] {"RealProperty", "AV-1"}, 
                            new string[] {"Resource", "AV-1"},
                            new string[] {"Rule", "AV-1"}, 
                            new string[] {"Site", "AV-1"}, 
                            new string[] {"Vision", "AV-1"},
                            new string[] {"superSubtype", "AV-1"}, 
                            new string[] {"WholePartType", "AV-1"}, 
                            new string[] {"ruleConstrainsActivity", "AV-1"}, 
                            new string[] {"Condition", "SV-1"},
                            new string[] {"Information", "SV-1"},
                            new string[] {"Location", "SV-1"},
                            new string[] {"OrganizationType", "SV-1"},
                            new string[] {"Performer", "SV-1"},
                            new string[] {"PersonRole", "SV-1"},
                            new string[] {"Resource", "SV-1"},
                            new string[] {"Rule", "SV-1"},
                            new string[] {"Data", "SV-1"},
                            new string[] {"superSubtype", "SV-1"}, 
                            new string[] {"WholePartType", "SV-1"},
                            new string[] {"OverlapType", "SV-1"},
                            new string[] {"Condition", "SV-10b"},
                            new string[] {"Information", "SV-10b"},
                            new string[] {"Location", "SV-10b"},
                            new string[] {"OrganizationType", "SV-10b"},
                            new string[] {"Performer", "SV-10b"},
                            new string[] {"PersonRole", "SV-10b"},
                            new string[] {"Resource", "SV-10b"},
                            new string[] {"Rule", "SV-10b"}, 
                            new string[] {"superSubtype", "SV-10b"}, 
                            new string[] {"WholePartType", "SV-10b"},
                            new string[] {"BeforeAfterType", "SV-10b"},
                            new string[] {"Condition", "SV-10c"},
                            new string[] {"Information", "SV-10c"},
                            new string[] {"Location", "SV-10c"},
                            new string[] {"OrganizationType", "SV-10c"},
                            new string[] {"Performer", "SV-10c"},
                            new string[] {"PersonRole", "SV-10c"},
                            new string[] {"Resource", "SV-10c"},
                            new string[] {"Rule", "SV-10c"}, 
                            new string[] {"superSubtype", "SV-10c"}, 
                            new string[] {"WholePartType", "SV-10c"},
                            new string[] {"Condition", "SV-2"},
                            new string[] {"Information", "SV-2"},
                            new string[] {"Location", "SV-2"},
                            new string[] {"OrganizationType", "SV-2"},
                            new string[] {"Performer", "SV-2"},
                            new string[] {"PersonRole", "SV-2"},
                            new string[] {"Resource", "SV-2"},
                            new string[] {"Rule", "SV-2"}, 
                            new string[] {"Data", "SV-2"}, 
                            new string[] {"superSubtype", "SV-2"}, 
                            new string[] {"WholePartType", "SV-2"},
                            new string[] {"OverlapType", "SV-2"},
                            new string[] {"Condition", "SvcV-1"},
                            new string[] {"Information", "SvcV-1"},
                            new string[] {"Data", "SvcV-1"},
                            new string[] {"Location", "SvcV-1"},
                            new string[] {"OrganizationType", "SvcV-1"},
                            new string[] {"Performer", "SvcV-1"},
                            new string[] {"PersonRole", "SvcV-1"},
                            new string[] {"Resource", "SvcV-1"},
                            new string[] {"Rule", "SvcV-1"}, 
                            new string[] {"System", "SvcV-1"}, 
                            new string[] {"superSubtype", "SvcV-1"}, 
                            new string[] {"WholePartType", "SvcV-1"},
                            new string[] {"OverlapType", "SvcV-1"},
                            new string[] {"Condition", "SvcV-10b"},
                            new string[] {"Information", "SvcV-10b"},
                            new string[] {"Location", "SvcV-10b"},
                            new string[] {"OrganizationType", "SvcV-10b"},
                            new string[] {"Performer", "SvcV-10b"},
                            new string[] {"PersonRole", "SvcV-10b"},
                            new string[] {"Resource", "SvcV-10b"},
                            new string[] {"Rule", "SvcV-10b"}, 
                            new string[] {"System", "SvcV-10b"}, 
                            new string[] {"superSubtype", "SvcV-10b"}, 
                            new string[] {"WholePartType", "SvcV-10b"},
                            new string[] {"BeforeAfterType", "SvcV-10b"},
                            new string[] {"Condition", "SvcV-10c"},
                            new string[] {"Information", "SvcV-10c"},
                            new string[] {"Location", "SvcV-10c"},
                            new string[] {"OrganizationType", "SvcV-10c"},
                            new string[] {"Performer", "SvcV-10c"},
                            new string[] {"PersonRole", "SvcV-10c"},
                            new string[] {"Resource", "SvcV-10c"},
                            new string[] {"Rule", "SvcV-10c"}, 
                            new string[] {"System", "SvcV-10c"}, 
                            new string[] {"superSubtype", "SvcV-10c"}, 
                            new string[] {"WholePartType", "SvcV-10c"},
                            new string[] {"Condition", "SV-4"},
                            new string[] {"Information", "SV-4"},
                            new string[] {"Location", "SV-4"},
                            new string[] {"OrganizationType", "SV-4"},
                            new string[] {"Performer", "SV-4"},
                            new string[] {"PersonRole", "SV-4"},
                            new string[] {"Resource", "SV-4"},
                            new string[] {"Rule", "SV-4"}, 
                            new string[] {"superSubtype", "SV-4"}, 
                            new string[] {"Data", "SV-4"}, 
                            new string[] {"WholePartType", "SV-4"},
                            new string[] {"OverlapType", "SV-4"},
                            new string[] {"Activity", "SV-8"},
                            new string[] {"Condition", "SV-8"},
                            new string[] {"Information", "SV-8"},
                            new string[] {"Location", "SV-8"},
                            new string[] {"OrganizationType", "SV-8"},
                            new string[] {"Performer", "SV-8"},
                            new string[] {"PersonRole", "SV-8"},
                            new string[] {"Resource", "SV-8"},
                            new string[] {"Rule", "SV-8"}, 
                            new string[] {"superSubtype", "SV-8"}, 
                            new string[] {"WholePartType", "SV-8"},
                            new string[] {"BeforeAfterType", "SV-8"},
                            new string[] {"activityPerformedByPerformer", "SV-8"},
                            new string[] {"HappensInType", "SV-8"},
                            new string[] {"PeriodType", "SV-8"},
                            new string[] {"Condition", "SvcV-4"},
                            new string[] {"Data", "SvcV-4"},
                            new string[] {"Information", "SvcV-4"},
                            new string[] {"Location", "SvcV-4"},
                            new string[] {"OrganizationType", "SvcV-4"},
                            new string[] {"Performer", "SvcV-4"},
                            new string[] {"PersonRole", "SvcV-4"},
                            new string[] {"Resource", "SvcV-4"},
                            new string[] {"Rule", "SvcV-4"}, 
                            new string[] {"System", "SvcV-4"},  
                            new string[] {"superSubtype", "SvcV-4"}, 
                            new string[] {"WholePartType", "SvcV-4"},
                            new string[] {"OverlapType", "SvcV-4"},
                            new string[] {"Condition", "SvcV-2"},
                            new string[] {"Information", "SvcV-2"},
                            new string[] {"Location", "SvcV-2"},
                            new string[] {"OrganizationType", "SvcV-2"},
                            new string[] {"Performer", "SvcV-2"},
                            new string[] {"PersonRole", "SvcV-2"},
                            new string[] {"Resource", "SvcV-2"},
                            new string[] {"Rule", "SvcV-2"}, 
                            new string[] {"System", "SvcV-2"}, 
                            new string[] {"superSubtype", "SvcV-2"}, 
                            new string[] {"WholePartType", "SvcV-2"},
                            new string[] {"Data", "SvcV-2"},
                            new string[] {"OverlapType", "SvcV-2"},
                            new string[] {"Condition", "DIV-2"},
                            new string[] {"Information", "DIV-2"},
                            new string[] {"Location", "DIV-2"},
                            new string[] {"OrganizationType", "DIV-2"},
                            new string[] {"Performer", "DIV-2"},
                            new string[] {"Resource", "DIV-2"},
                            new string[] {"Rule", "DIV-2"}, 
                            new string[] {"superSubtype", "DIV-2"}, 
                            new string[] {"WholePartType", "DIV-2"},
                            //new string[] {"OverlapType", "DIV-2"},
                            new string[] {"Condition", "DIV-3"},
                            new string[] {"Information", "DIV-3"},
                            new string[] {"Location", "DIV-3"},
                            new string[] {"OrganizationType", "DIV-3"},
                            new string[] {"Performer", "DIV-3"},
                            new string[] {"Resource", "DIV-3"},
                            new string[] {"Rule", "DIV-3"}, 
                            new string[] {"superSubtype", "DIV-3"}, 
                            new string[] {"WholePartType", "DIV-3"},
                            new string[] {"typeInstance", "DIV-3"},
                            //new string[] {"OverlapType", "DIV-3"},
                            new string[] {"Condition", "PV-1"},
                            new string[] {"Information", "PV-1"},
                            new string[] {"Location", "PV-1"},
                            new string[] {"Performer", "PV-1"},
                            new string[] {"Resource", "PV-1"},
                            new string[] {"Rule", "PV-1"}, 
                            new string[] {"superSubtype", "PV-1"}, 
                            new string[] {"WholePartType", "PV-1"}, 
                            new string[] {"PeriodType", "PV-2"},
                            new string[] {"HappensInType", "PV-2"},
                            new string[] {"Condition", "PV-2"},
                            new string[] {"Information", "PV-2"},
                            new string[] {"Location", "PV-2"},
                            new string[] {"Performer", "PV-2"},
                            new string[] {"Resource", "PV-2"},
                            new string[] {"Rule", "PV-2"}, 
                            new string[] {"superSubtype", "PV-2"}, 
                            new string[] {"WholePartType", "PV-2"}, 
                            new string[] {"activityPerformedByPerformer", "PV-2"},
                            new string[] {"OrganizationType", "PV-2"},
                            new string[] {"Activity", "AV-2"},
                            new string[] {"ArchitecturalDescription", "AV-2"},
                            new string[] {"Capability", "AV-2"},
                            new string[] {"Condition", "AV-2"},
                            new string[] {"Data", "AV-2"},
                            new string[] {"Facility", "AV-2"},
                            new string[] {"Guidance", "AV-2"},
                            new string[] {"Information", "AV-2"},
                            new string[] {"Location", "AV-2"},
                            new string[] {"MeasureOfDesire", "AV-2"},
                            new string[] {"MeasureOfEffect", "AV-2"},
                            new string[] {"OrganizationType", "AV-2"},
                            new string[] {"Performer", "AV-2"},
                            new string[] {"PersonRole", "AV-2"},
                            new string[] {"ProjectType", "AV-2"},
                            new string[] {"RealProperty", "AV-2"}, 
                            new string[] {"Resource", "AV-2"},
                            new string[] {"Rule", "AV-2"}, 
                            new string[] {"Service", "AV-2"}, 
                            new string[] {"ServiceDescription", "AV-2"}, 
                            new string[] {"System", "AV-2"}, 
                            new string[] {"Site", "AV-2"}, 
                            new string[] {"Thing", "AV-2"}, 
                            new string[] {"Vision", "AV-2"},
                            new string[] {"superSubtype", "AV-2"}, 
                            new string[] {"WholePartType", "AV-2"}, 
                            new string[] {"ruleConstrainsActivity", "AV-2"}, 
                            new string[] {"Country", "AV-2"}, 
                            new string[] {"RegionOfCountry", "AV-2"}, 
                            new string[] {"PeriodType", "AV-2"}, 
                            new string[] {"DataType", "AV-2"},
                            };

        //PES Data Structures

        private class Thing
        {
            public string type;
            public string id;
            public string name;
            public object value;
            public string place1;
            public string place2;
            public string foundation;
            public string value_type;
        }

        private class Location
        {
            public string id;
            public string element_id;
            public string top_left_x;
            public string top_left_y;
            public string top_left_z;
            public string bottom_right_x;
            public string bottom_right_y;
            public string bottom_right_z;
        }

        private class View
        {
            public string type;
            public string id;
            public string name;
            public List<Thing> mandatory;
            public List<Thing> optional;
        }

        //Helper Functions

        //private static string Resource_Flow_Type(string type, string view, string place1, string place2, Dictionary<string, Thing> things)
        //{
        //    string type1 = things[place1].type;
        //    string type2 = things[place2].type;

        //    if (type == "SF" && view.Contains("SV"))
        //    {
        //        return "System Data Flow (DM2rx)";
        //    }

        //    if (type == "SF" && view.Contains("SvcV"))
        //    {
        //        if (type1 == "Service" && type2 == "Service")
        //        {
        //            return "Service Resource Flow (DM2rx)";
        //        }
        //        else
        //        {
        //            return "Service Data Flow (DM2rx)";
        //        }
        //    }

        //    if (type == "Needline" && view.Contains("SvcV"))
        //        return "Physical Resource Flow (DM2rx)";

        //    if (type == "Needline" && view.Contains("SV"))
        //    {
        //        if (type1 == "System" && type2 == "System")    
        //            return "System Resource Flow (DM2rx)";
        //        else
        //            return "Physical Resource Flow (DM2rx)";
        //    }
        //    else
        //        return "Need Line (DM2rx)";

        //}

        public static void Decode(string base64String, string outputFileName)
        {
            byte[] binaryData;
            try
            {
                binaryData =
                   System.Convert.FromBase64String(base64String);
            }
            catch (System.ArgumentNullException)
            {
                System.Console.WriteLine("Base 64 string is null.");
                return;
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("Base 64 string length is not " +
                   "4 or is not an even multiple of 4.");
                return;
            }

            // Write out the decoded data.
            System.IO.FileStream outFile;
            try
            {
                outFile = new System.IO.FileStream(outputFileName,
                                           System.IO.FileMode.Create,
                                           System.IO.FileAccess.Write);
                outFile.Write(binaryData, 0, binaryData.Length);
                outFile.Close();
            }
            catch (System.Exception exp)
            {
                // Error creating stream or writing to it.
                System.Console.WriteLine("{0}", exp.Message);
            }
        }

        public static string Encode(string inputFileName)
        {
            System.IO.FileStream inFile;
            byte[] binaryData;

            try
            {
                inFile = new System.IO.FileStream(inputFileName,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read);
                binaryData = new Byte[inFile.Length];
                long bytesRead = inFile.Read(binaryData, 0,
                                     (int)inFile.Length);
                inFile.Close();
            }
            catch (System.Exception exp)
            {
                // Error creating stream or reading from it.
                System.Console.WriteLine("{0}", exp.Message);
                return null;
            }

            // Convert the binary input into Base64 UUEncoded output. 
            string base64String;
            try
            {
                base64String =
                  System.Convert.ToBase64String(binaryData,
                                         0,
                                         binaryData.Length);
            }
            catch (System.ArgumentNullException)
            {
                System.Console.WriteLine("Binary data array is null.");
                return null;
            }

            return base64String;
        }

        public static void MergeDictionaries<OBJ1, OBJ2>(this IDictionary<OBJ1, List<OBJ2>> dict1, IDictionary<OBJ1, List<OBJ2>> dict2)
        {
            foreach (var kvp2 in dict2)
            {
                if (dict1.ContainsKey(kvp2.Key))
                {
                    dict1[kvp2.Key].AddRange(kvp2.Value);
                    continue;
                }
                dict1.Add(kvp2);
            }
        }

        public static void MergeDictionaries<OBJ1, OBJ2>(this IDictionary<OBJ1, OBJ2> dict1, IDictionary<OBJ1, OBJ2> dict2)
        {
            foreach (KeyValuePair<OBJ1, OBJ2> entry in dict2)
            {
                dict1[entry.Key] = entry.Value;
            }
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }

        private static string Find_DM2_Type(string input)
        {

            foreach (string[] current_lookup in Element_Lookup)
            {
                if (input == current_lookup[1])
                    return current_lookup[0];
            }
            return null;
        }

        //private static string Find_DM2_Type_RSA(string input)
        //{

        //    foreach (string[] current_lookup in RSA_Element_Lookup)
        //    {
        //        if (input == current_lookup[1])
        //            return current_lookup[0];
        //    }
        //    return null;
        //}

        private static string Find_Def_DM2_Type(string input, List<Thing> things)
        {
            foreach (Thing thing in things)
            {
                if (input == thing.id)
                    return thing.type;
            }
            return null;
        }

        private static string Find_DM2_View(string input)
        {

            foreach (string[] current_lookup in View_Lookup)
            {
                if (input == current_lookup[1])
                    return current_lookup[0];
            }
            return null;
        }

        private static string Find_View_SA_Minor_Type(string input)
        {

            foreach (string[] current_lookup in View_Lookup)
            {
                if (input == current_lookup[1])
                    return current_lookup[2];
            }
            return null;
        }

        private static string Find_DIV2_Type(Thing input, ref Dictionary<string, List<Thing>> tt1, ref Dictionary<string, List<Thing>> tt2)
        {
            List<Thing> values;
            List<Thing> values2;

            if (tt2.TryGetValue(input.id, out values))
                if (tt1.TryGetValue(input.id, out values2))
                    return "Attribute";
                else
                    return "Data Element";

            return input.type;
        }

        private static string Find_Symbol_Element_SA_Minor_Type(ref string input, string view)
        {

            foreach (string[] first_lookup in Element_Lookup)
            {
                if (input == first_lookup[1])
                {
                    foreach (string[] second_lookup in SA_Element_View_Lookup)
                    {
                        if (view == second_lookup[0] && input == second_lookup[1])
                        {
                            input = second_lookup[2];
                            return second_lookup[3];
                        }
                    }
                    return first_lookup[3];
                }

            }
            //foreach (string[] current_lookup in SA_Element_Lookup)
            //{
            //    if (input == current_lookup[1])
            //        return current_lookup[3];
            //}
            return null;
        }

        private static string Find_Definition_Element_SA_Minor_Type(string input)
        {

            foreach (string[] current_lookup in Element_Lookup)
            {
                if (input == current_lookup[1])
                    return current_lookup[4];
            }
            //foreach (string[] current_lookup in SA_Element_Lookup)
            //{
            //    if (input == current_lookup[1])
            //        return current_lookup[4];
            //}
            return null;
        }

        private static string Find_SA_Relationship_Type(string rela_type, string thing_type, string place)
        {

            //foreach (string[] current_lookup in Tuple_Lookup)
            //{
            //    if (rela_type == current_lookup[0] && thing_type == current_lookup[4] && (place == "1" ? (current_lookup[3] == "1" || current_lookup[3] == "5") : (current_lookup[3] == "2" || current_lookup[3] == "4")))
            //            return current_lookup[1];
            //}
            foreach (string[] current_lookup in Tuple_Type_Lookup)
            {
                if (rela_type == current_lookup[0] && thing_type == current_lookup[4] && (place == "1" ? (current_lookup[3] == "1" || current_lookup[3] == "5") : (current_lookup[3] == "2" || current_lookup[3] == "4")))
                    return current_lookup[1];
            }

            return null;
        }

        private static bool Allowed_Element(string view, string id, ref Dictionary<string, Thing> dict)
        {
            Thing value;
            if (dict.TryGetValue(id, out value))
                return Allowed_Class(view, value.type);

            return false;
        }

        private static bool Allowed_Needline(string view, List<Thing> values, ref Dictionary<string, Thing> dict)
        {
            foreach (Thing thing in values)
            {
                if (thing.type == "activityPerformedByPerformer")
                    if (Allowed_Element(view, thing.place1, ref dict) == false)
                        return false;
            }

            return true;
        }

        private static bool Correct_Needline(List<Thing> values, List<Thing> view)
        {

            int count = 0;

            foreach (Thing thing in values)
            {
                if (thing.type == "activityPerformedByPerformer")
                {
                    bool place1 = false;

                    foreach (Thing item in view)
                    {
                        if (item.place2 == thing.place1)
                            place1 = true;
                    }

                    if (place1 == true)
                        count++;
                }
            }

            if (count == 2)
                return true;

            return false;
        }

        private static bool Allowed_Class(string view, string type)
        {
            foreach (string[] current_lookup in Mandatory_Lookup)
            {
                if (current_lookup[1] != view)
                    continue;

                if (type == current_lookup[0])
                    return true;
            }

            foreach (string[] current_lookup in Optional_Lookup)
            {
                if (current_lookup[1] != view)
                    continue;

                if (type == current_lookup[0])
                    return true;
            }

            return false;
        }

        private static bool Proper_View(List<Thing> input, string name, string type, string id, ref List<string> errors)
        {
            bool found = true;
            bool test = true;
            int count = 0;

            foreach (string[] current_lookup in Mandatory_Lookup)
            {
                if (current_lookup[1] != type)
                    continue;

                found = false;
                foreach (Thing thing in input)
                {
                    if (thing.type == current_lookup[0])
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    errors.Add("Diagram error," + id + "," + name + "," + type + ",Missing Mandatory Element: " + current_lookup[0] + "\r\n");
                    test = false;
                    test = false;
                    count++;
                }
            }
            return test;
        }

        private static string Find_Mandatory_Optional(string element, string name, string view, string id, ref List<string> errors)
        {

            foreach (string[] current_lookup in Mandatory_Lookup)
            {
                if (element == current_lookup[0] && view == current_lookup[1])
                    return "Mandatory";
            }

            foreach (string[] current_lookup in Optional_Lookup)
            {
                if (element == current_lookup[0] && view == current_lookup[1])
                    return "Optional";
            }

            errors.Add("Diagram error," + id + "," + name + "," + view + ",Element Ignored. Type Not Allowed: " + element + "\r\n");
            return "$none$";
        }

        private static void Add_Tuples(ref List<List<Thing>> input_list, ref List<List<Thing>> sorted_results, List<Thing> relationships, ref List<string> errors)
        {
            //List<List<Thing>> sorted_results = input_list_new;
            bool place1 = false;
            bool place2 = false;
            Thing value;

            //foreach (List<Thing> old_view in input_list)
            for (int i = 0; i < input_list.Count; i++)
            {
                List<Thing> things_view = new List<Thing>();
                List<Thing> new_view = new List<Thing>();
                List<Thing> other_view = new List<Thing>();
                Dictionary<string, Thing> dic;


                //if (old_view.Where(x => x.value != null).Where(x => (string)x.value == "$none$").Count() > 0)
                //    new_view = old_view.Where(x => x.value != null).Where(x => (string)x.value == "$none$").ToList();

                other_view = input_list[i].Where(x => x.value != null).Where(x => (string)x.value != "$none$" && ((string)x.value).Substring(0, 1) != "_").ToList();

                if (sorted_results.Count == i)
                {

                    new_view.AddRange(input_list[i].Where(x => x.value == null).ToList());
                    new_view.AddRange(input_list[i].Where(x => x.value != null).Where(x => ((string)x.value).Substring(0, 1) == "_"));


                    foreach (Thing thing in other_view)
                    {
                        if (Find_Mandatory_Optional((string)thing.value, other_view.First().name, thing.type, thing.place1, ref errors) != "$none$")
                            new_view.Add(thing);
                    }

                    //remove
                    //var duplicateKeys = new_view.GroupBy(x => x.place2)
                    //        .Where(group => group.Count() > 1)
                    //        .Select(group => group.Key);

                    //List<string> test = duplicateKeys.ToList();

                    new_view = new_view.GroupBy(x => x.place2).Select(y => y.First()).ToList();

                    dic = new_view.Where(x => x.place2 != null).ToDictionary(x => x.place2, x => x);

                }
                else
                {
                    other_view = other_view.GroupBy(x => x.place2).Select(y => y.First()).ToList();

                    dic = other_view.Where(x => x.place2 != null).ToDictionary(x => x.place2, x => x);
                }


                foreach (Thing rela in relationships)
                {
                    place1 = false;
                    place2 = false;

                    if (dic.TryGetValue(rela.place1, out value))
                        place1 = true;

                    if (dic.TryGetValue(rela.place2, out value))
                        place2 = true;

                    if (place1 && place2)
                    {
                        if (rela.type == "OverlapType")
                        {
                            foreach (Thing overlap in input_list[i])
                            {
                                if (overlap.place2 == (string)rela.value)
                                {
                                    new_view.Add(new Thing { place1 = value.place1, place2 = rela.id, value = rela.type, type = value.type, value_type = "$none$" });
                                    break;
                                }
                            }
                        }
                        else
                            new_view.Add(new Thing { place1 = value.place1, place2 = rela.id, value = rela.type, type = value.type, value_type = "$none$" });
                    }
                }

                if (sorted_results.Count == i)
                    sorted_results.Add(new_view);
                else
                    sorted_results[i] = sorted_results[i].Union(new_view).ToList();
            }

            // return sorted_results;
        }

        private static List<Thing> Add_Places(Dictionary<string, Thing> things, List<Thing> values)
        {
            values = values.Distinct().ToList();
            IEnumerable<Thing> results = new List<Thing>(values);
            List<Thing> places = new List<Thing>();
            Thing value;

            foreach (Thing rela in values)
            {

                if (things.TryGetValue(rela.place1, out value))
                    places.Add(value);

                if (things.TryGetValue(rela.place2, out value))
                    places.Add(value);

            }

            results = results.Concat(places.Distinct());
            return results.ToList();
        }

        private static List<List<Thing>> Get_Tuples_place1(Thing input, IEnumerable<Thing> relationships)
        {
            List<Thing> results = new List<Thing>();

            foreach (Thing rela in relationships)
            {

                if (input.id == rela.place1)
                {
                    results.Add(new Thing { id = rela.id, type = Find_SA_Relationship_Type(rela.type, input.type, "1"), place1 = input.id, place2 = rela.place2, value = input, value_type = "$Thing$" });
                }
            }

            return results.GroupBy(x => x.type).Select(group => group.Distinct().ToList()).ToList(); ;
        }

        private static List<List<Thing>> Get_Tuples_place2(Thing input, IEnumerable<Thing> relationships)
        {
            List<Thing> results = new List<Thing>();

            foreach (Thing rela in relationships)
            {

                if (input.id == rela.place2)
                {
                    results.Add(new Thing { id = rela.id, type = Find_SA_Relationship_Type(rela.type, input.type, "2"), place1 = input.id, place2 = rela.place1, value = input, value_type = "$Thing$" });
                }
            }

            return results.GroupBy(x => x.type).Select(group => group.Distinct().ToList()).ToList(); ;
        }

        private static List<List<Thing>> Get_Tuples_id(Thing input, IEnumerable<Thing> relationships)
        {
            List<Thing> results = new List<Thing>();

            foreach (Thing rela in relationships)
            {

                if (input.id == rela.id)
                {
                    results.Add(new Thing { id = rela.id, type = "performerTarget", place1 = input.id, place2 = rela.place1, value = input, value_type = "$Thing$" });
                    results.Add(new Thing { id = rela.id, type = "performerSource", place1 = input.id, place2 = rela.place2, value = input, value_type = "$Thing$" });
                }
            }

            return results.GroupBy(x => x.type).Select(group => group.Distinct().ToList()).ToList(); ;
        }

        ////////////////////
        //Main
        ////////////////////

        public static bool SA2PES(byte[] input, ref string output, ref string errors, bool all_view_flag)
        {
            IEnumerable<Thing> things = new List<Thing>();
            IEnumerable<Thing> tuple_types = new List<Thing>();
            IEnumerable<Thing> tuples = new List<Thing>();
            IEnumerable<Thing> results;
            IEnumerable<Thing> results2;
            IEnumerable<Location> locations;
            List<View> views = new List<View>();
            List<Thing> mandatory_list = new List<Thing>();
            List<Thing> optional_list = new List<Thing>();
            string temp;
            Dictionary<string, List<Thing>> doc_blocks_data;
            Dictionary<string, string> diagrams;
            Dictionary<string, string> not_processed_diagrams;
            Dictionary<string, Thing> things_dic;
            Dictionary<string, Thing> values_dic;
            Dictionary<string, Thing> values_dic2;
            Dictionary<string, List<Thing>> bpmn_lookup;
            Dictionary<string, List<Thing>> doc_blocks_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> description_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV1_pic_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> needline_mandatory_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> CV1_mandatory_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> CV1_optional_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> CV4_mandatory_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> CV4_optional_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> needline_optional_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV2_support_mandatory_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV2_support_optional_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV4_support_optional_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV2_support_mandatory_views_2 = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV4_support_optional_views_2 = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV5b_aro_mandatory_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV6c_aro_optional_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> OV5b_aro_optional_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> PV1_mandatory_views = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> DIV2_3_optional = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> DIV2_3_mandatory = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> results_dic;
            Dictionary<string, List<Thing>> results_dic2;
            Dictionary<string, List<Thing>> results_dic3;
            Dictionary<string, List<Thing>> results_dic4;
            Dictionary<string, List<Thing>> period_dic = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> datatype_mandatory_dic = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> datatype_optional_dic = new Dictionary<string, List<Thing>>();
            Dictionary<string, List<Thing>> aro;
            Dictionary<string, List<Thing>> aro2;
            XElement root = XElement.Load(new MemoryStream(input));
            List<List<Thing>> sorted_results = new List<List<Thing>>();
            List<List<Thing>> sorted_results_new = new List<List<Thing>>();
            List<List<Thing>> view_holder = new List<List<Thing>>();
            bool representation_scheme = false;
            List<Thing> values = new List<Thing>();
            List<Thing> values2 = new List<Thing>();
            List<Thing> values3 = new List<Thing>();
            List<Thing> values4 = new List<Thing>();
            List<Thing> values5 = new List<Thing>();
            List<Thing> values6 = new List<Thing>();
            List<Thing> values7 = new List<Thing>();
            Thing value;
            Thing value2;
            int count = 0;
            int count2 = 0;
            bool add = false;
            bool test = true;
            List<string> errors_list = new List<string>();


            //Diagram Type error

            results =
                from result in root.Elements("Class").Elements("SADiagram")
                select new Thing
                            {
                                type = (string)result.Attribute("SAObjMinorTypeName"),
                                id = (string)result.Attribute("SAObjId"),
                                name = ((string)result.Attribute("SAObjName")).Replace("&", " And "),
                                value = "$none$",
                                place1 = "$none$",
                                place2 = "$none$",
                                foundation = "Thing",
                                value_type = "$none$"
                            };

            diagrams = View_Lookup.ToDictionary(x => x[1], x => x[0]);
            not_processed_diagrams = Not_Processed_View_Lookup.ToDictionary(x => x[1], x => x[0]);
            foreach (Thing thing in results)
            {
                if (!diagrams.TryGetValue(thing.type, out temp))
                {
                    if (not_processed_diagrams.TryGetValue(thing.type, out temp))
                    {
                        errors_list.Add("Diagram error," + thing.id + "," + thing.name + "," + temp + ", Type Not Allowed - Diagram Ignored: " + thing.type + "\r\n");
                    }
                    else
                    {
                        errors_list.Add("Diagram error," + thing.id + "," + thing.name + ",Unknown, Type Not Allowed - Diagram Ignored: " + thing.type + "\r\n");
                    }
                }
            }

            //Bulk Translations

            //Doc Block

            results_dic =
                (from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol")
                 where (string)result.Attribute("SAObjMinorTypeName") == "Doc Block"
                 select new
                 {
                     key = (string)result.Parent.Attribute("SAObjId"),
                     value = new List<Thing> {new Thing
                        {
                        type = "Information",
                        id = (string)result.Attribute("SAObjId")+"_1",
                        name = "Doc Block Comment",
                        value = ((string)result.Attribute("SASymZPDesc")+"").Replace("&", " And ").Replace("\"","'"),
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = "IndividualType",
                        value_type = "exemplarText"
                        },new Thing
                    {
                        type = "Information",
                        id = (string)result.Attribute("SAObjId")+"_2",
                        name = "Doc Block Type",
                        value = (string)result.Parent.Attribute("SAObjMinorTypeName"),
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = "IndividualType",
                        value_type = "exemplarText"
                    },new Thing
                    {
                        type = "Information",
                        id = (string)result.Attribute("SAObjId")+"_3",
                        name = "Doc Block Date",
                        value = (string)result.Parent.Attribute("SAObjUpdateDate"),
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = "IndividualType",
                        value_type = "exemplarText"
                    },new Thing
                    {
                        type = "Information",
                        id = (string)result.Attribute("SAObjId")+"_4",
                        name = "Doc Block Time",
                        value = (string)result.Parent.Attribute("SAObjUpdateTime"),
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = "IndividualType",
                        value_type = "exemplarText"
                    }}
                 }).ToDictionary(a => a.key, a => a.value);

            if (results_dic.Count() > 0)
            {
                doc_blocks_data = new Dictionary<string, List<Thing>>(results_dic);

                foreach (KeyValuePair<string, List<Thing>> entry in results_dic)
                {
                    List<Thing> thing_list = new List<Thing>();
                    foreach (Thing thing in entry.Value)
                    {
                        thing_list.Add(new Thing
                        {
                            type = "describedBy",
                            id = thing.id + entry.Key,
                            foundation = "namedBy",
                            place1 = entry.Key,
                            place2 = thing.id,
                            name = "$none$",
                            value = "$none$",
                            value_type = "$none$"
                        });
                    }
                    tuples = tuples.Concat(thing_list);

                    doc_blocks_views.Add(entry.Key, new List<Thing>(thing_list));
                }

                results_dic =
                    (from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol")
                     where (string)result.Attribute("SAObjMinorTypeName") == "Doc Block"
                     select new
                     {
                         key = (string)result.Parent.Attribute("SAObjId"),
                         value = new List<Thing> {new Thing
                            {
                                type = "Thing",
                                id = (string)result.Attribute("SAObjId"),
                                name = ((string)result.Parent.Attribute("SAObjName")).Replace("&", " And "),
                                value = "$none$",
                                place1 = "$none$",
                                place2 = "$none$",
                                foundation = "Thing",
                                value_type = "$none$"
                            }}
                     }).ToDictionary(a => a.key, a => a.value);

                MergeDictionaries(doc_blocks_data, results_dic);

                things = things.Concat(doc_blocks_data.SelectMany(x => x.Value));

                MergeDictionaries(doc_blocks_views, doc_blocks_data);
            }

            //Regular Things

            foreach (string[] current_lookup in Element_Lookup)
            {

                results =
                    from result in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SAObjMinorTypeName") == current_lookup[1]
                    select new Thing
                    {
                        type = current_lookup[0],
                        id = (string)result.Attribute("SAObjId"),
                        name = ((string)result.Attribute("SAObjName")).Replace("&", " And ").Replace("<", "").Replace(">", ""),
                        value = "$none$",
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = current_lookup[2],
                        value_type = "$none$"
                    };

                things = things.Concat(results.ToList());

                if (current_lookup[1] != "Entity" && current_lookup[1] != "Access Path" && current_lookup[1] != "Index" && current_lookup[1] != "Table")
                {
                    results_dic =
                        (from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty")
                         where (string)result.Parent.Attribute("SAObjMinorTypeName") == current_lookup[1]
                         where (string)result.Attribute("SAPrpName") == "Description"
                         select new
                         {
                             key = (string)result.Parent.Attribute("SAObjId"),
                             value = new List<Thing> {
                            new Thing
                            {
                                type = "Information",
                                id = (string)result.Parent.Attribute("SAObjId") + "_9",
                                name = ((string)result.Parent.Attribute("SAObjName")).Replace("&", " And ").Replace("<", "").Replace(">", "") + " Description",
                                value = ((((((string)result.Attribute("SAPrpValue")).Replace("@", " At ")).Replace("\"","'")).Replace("&", " And ")).Replace("<", "")).Replace(">", ""),
                                place1 = (string)result.Parent.Attribute("SAObjId"),
                                place2 = (string)result.Parent.Attribute("SAObjId") + "_9",
                                foundation = "IndividualType",
                                value_type = "exemplarText"
                            }
                        }
                         }).ToDictionary(a => a.key, a => a.value);

                    things = things.Concat(results_dic.SelectMany(x => x.Value));

                    foreach (Thing thing in results_dic.SelectMany(x => x.Value))
                    {

                        value = new Thing
                        {
                            type = "describedBy",
                            id = thing.place1 + "_10",
                            foundation = "namedBy",
                            place1 = thing.place1,
                            place2 = thing.place2,
                            name = "$none$",
                            value = "$none$",
                            value_type = "$none$"
                        };
                        tuples = tuples.Concat(new List<Thing> { value });
                        description_views.Add(thing.place1, new List<Thing> { value });
                    }

                    MergeDictionaries(description_views, results_dic);
                }
                else if (current_lookup[1] == "Index")
                {
                    results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == current_lookup[1]
                        where (string)result.Parent.Attribute("SAPrpName") == "Description"

                        select new Thing
                           {
                               type = "Information",
                               id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity") + "_9",
                               name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And ") + " Primary Key",
                               value = (string)result.Attribute("SALinkIdentity"),
                               place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                               place2 = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity") + "_9",
                               foundation = "IndividualType",
                               value_type = "exemplarText"
                           };

                    things = things.Concat(results);

                    sorted_results = results.GroupBy(x => x.place1).Select(group => group.ToList()).ToList();

                    foreach (List<Thing> view in sorted_results)
                    {
                        values = new List<Thing>();
                        foreach (Thing thing in view)
                        {
                            value = new Thing
                            {
                                type = "describedBy",
                                id = thing.place2 + "_10",
                                foundation = "namedBy",
                                place1 = thing.place1,
                                place2 = thing.place2,
                                name = "$none$",
                                value = "$none$",
                                value_type = "$none$"
                            };
                            tuples = tuples.Concat(new List<Thing> { value });
                            values.Add(value);
                            values.Add(thing);
                        }
                        description_views.Add(view.First().place1, values);
                    }

                    //MergeDictionaries(description_views, results_dic);
                }
            }

            //OV-1 Picture

            results =
                from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol").Elements("SAPicture")
                where (string)result.Parent.Attribute("SAObjMinorTypeName") == "Picture"
                where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "OV-01 High Level Operational Concept (DM2)"
                select
                    //new {
                    //    key = (string)result.Parent.Parent.Attribute("SAObjId"),
                    //    value = new List<Thing> {
                        new Thing
                    {
                        type = "ArchitecturalDescription",
                        id = (string)result.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = (string)result.Attribute("SAPictureData"),
                        place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                        place2 = (string)result.Parent.Attribute("SAObjId"),
                        foundation = "IndividualType",
                        value_type = "exemplarText"
                    };
            //}}).ToDictionary(a => a.key, a => a.value);

            OV1_pic_views = results.GroupBy(x => x.place1).ToDictionary(x => x.Key, x => x.ToList());

            if (OV1_pic_views.Count() > 0)
            {
                representation_scheme = true;
                foreach (KeyValuePair<string, List<Thing>> entry in OV1_pic_views)
                {
                    foreach (Thing thing in entry.Value)
                    {
                        tuples = tuples.Concat(new List<Thing>{new Thing
                            {
                            type = "representationSchemeInstance",
                            id = thing.id+"_1",
                            name = "$none$",
                            value = "$none$",
                            place1 = "_rs1",
                            place2 = thing.id,
                            foundation = "typeInstance",
                            value_type = "$none$"
                            }});
                    }
                }
                things = things.Concat(OV1_pic_views.SelectMany(x => x.Value));
            }

            //Regular tuples

            //foreach (string[] current_lookup in Tuple_Lookup)
            //{
            //    if (current_lookup[3] == "1")
            //    {
            //        results =
            //            from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
            //            where (string)result.Parent.Attribute("SAPrpName") == current_lookup[1]
            //            select new Thing
            //            {
            //                type = current_lookup[0],
            //                id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity"),
            //                name = "$none$",
            //                value = "$none$",
            //                place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
            //                place2 = (string)result.Attribute("SALinkIdentity"),
            //                foundation = current_lookup[2],
            //                value_type = "$none$"
            //            };
            //    }
            //    else
            //    {
            //        results =
            //            from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
            //            where (string)result.Parent.Attribute("SAPrpName") == current_lookup[1]
            //            select new Thing
            //            {
            //                type = current_lookup[0],
            //                id = (string)result.Attribute("SALinkIdentity") + (string)result.Parent.Parent.Attribute("SAObjId"),
            //                name = "$none$",
            //                value = "$none$",
            //                place2 = (string)result.Parent.Parent.Attribute("SAObjId"),
            //                place1 = (string)result.Attribute("SALinkIdentity"),
            //                foundation = current_lookup[2],
            //                value_type = "$none$"
            //            };
            //    }
            //    tuples = tuples.Concat(results.ToList());
            //}

            //tuples = tuples.GroupBy(x => x.id).Select(grp => grp.First());

            //Regular TupleTypes

            foreach (string[] current_lookup in Tuple_Type_Lookup)
            {
                if (current_lookup[3] == "1")
                {
                    results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == current_lookup[1]
                        select new Thing
                        {
                            type = current_lookup[0],
                            id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity"),
                            name = "$none$",
                            value = "$none$",
                            place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place2 = (string)result.Attribute("SALinkIdentity"),
                            foundation = current_lookup[2],
                            value_type = "$none$"
                        };

                    tuple_types = tuple_types.Concat(results.ToList());

                }
                else if (current_lookup[3] == "2")
                {
                    results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == current_lookup[1]
                        select new Thing
                        {
                            type = current_lookup[0],
                            id = (string)result.Attribute("SALinkIdentity") + (string)result.Parent.Parent.Attribute("SAObjId"),
                            name = "$none$",
                            value = "$none$",
                            place2 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place1 = (string)result.Attribute("SALinkIdentity"),
                            foundation = current_lookup[2],
                            value_type = "$none$"
                        };

                    tuple_types = tuple_types.Concat(results.ToList());

                }
                else if (current_lookup[3] == "4")
                {
                    results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == current_lookup[1]
                        where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == current_lookup[4]
                        select new Thing
                        {
                            type = current_lookup[0],
                            id = (string)result.Attribute("SALinkIdentity") + (string)result.Parent.Parent.Attribute("SAObjId"),
                            name = "$none$",
                            value = "$none$",
                            place2 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place1 = (string)result.Attribute("SALinkIdentity"),
                            foundation = current_lookup[2],
                            value_type = "$none$"
                        };

                    tuple_types = tuple_types.Concat(results.ToList());

                }
                else if (current_lookup[3] == "5")
                {
                    results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == current_lookup[1]
                        where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == current_lookup[4]
                        select new Thing
                        {
                            type = current_lookup[0],
                            id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity"),
                            name = "$none$",
                            value = "$none$",
                            place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place2 = (string)result.Attribute("SALinkIdentity"),
                            foundation = current_lookup[2],
                            value_type = "$none$"
                        };

                    tuple_types = tuple_types.Concat(results.ToList());

                }

            }

            tuple_types = tuple_types.GroupBy(x => x.id).Select(grp => grp.First());

            //Complex Translations

            //CV-1

            results =
                    from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol")
                    where (string)result.Parent.Attribute("SAObjMinorTypeName") == "CV-01 Vision (DM2)"
                    where (string)result.Attribute("SAObjMinorTypeName") == "Capability (DM2)"
                    select new Thing
                    {
                        type = "CV-01 View",
                        id = "$none$",
                        name = ((string)result.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = ((string)result.Attribute("SAObjName")).Replace("&", " And "),
                        place1 = (string)result.Parent.Attribute("SAObjId"),
                        place2 = (string)result.Attribute("SASymIdDef"),
                        foundation = "$none$",
                        value_type = "$Capability Name$"
                    };

            if (results.Count() > 0)
            {
                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Vision",
                    id = results.First().place1 + "_1",
                    name = results.First().name,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                things = things.Concat(values);

                CV1_mandatory_views.Add(results.First().place1, values);
            }

            foreach (Thing thing in results.ToList())
            {
                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Resource",
                    id = thing.place2 + "_1",
                    name = thing.value + "_DesiredResourceState",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "MeasureOfEffect",
                    id = thing.place2 + "_4",
                    name = thing.value + "_MeasureOfEffect",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "MeasureOfDesire",
                    id = thing.place2 + "_5",
                    name = thing.value + "_MeasureOfDesire",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                things = things.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "visionRealizedByDesiredResourceState",
                    id = thing.place2 + "_2",
                    name = thing.value + "_visionRealizedByDesiredResourceState",
                    value = "$none$",
                    place1 = thing.place1 + "_1",
                    place2 = thing.place2 + "_1",
                    foundation = "CoupleType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "desiredResourceStateOfCapability",
                    id = thing.place2 + "_3",
                    name = thing.value + "_desiredResourceStateOfCapability",
                    value = "$none$",
                    place1 = thing.place2,
                    place2 = thing.place2 + "_1",
                    foundation = "WholePartType",
                    value_type = "$none$"
                });

                tuple_types = tuple_types.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "effectMeasure",
                    id = thing.place2 + "_6",
                    name = thing.value + "_effectMeasure",
                    value = "$none$",
                    place1 = thing.place2 + "_1",
                    place2 = thing.place2 + "_4",
                    foundation = "superSubtype",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "desireMeasure",
                    id = thing.place2 + "_7",
                    name = thing.value + "_desireMeasure",
                    value = "$none$",
                    place1 = thing.place2 + "_1",
                    place2 = thing.place2 + "_5",
                    foundation = "superSubtype",
                    value_type = "$none$"
                });

                tuples = tuples.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Resource",
                    id = thing.place2 + "_1",
                    name = thing.value + "_DesiredResourceState",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                CV1_optional_views.Add(thing.place2, values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "MeasureOfEffect",
                    id = thing.place2 + "_4",
                    name = thing.value + "_MeasureOfEffect",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "MeasureOfDesire",
                    id = thing.place2 + "_5",
                    name = thing.value + "_MeasureOfDesire",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "visionRealizedByDesiredResourceState",
                    id = thing.place2 + "_2",
                    name = thing.value + "_visionRealizedByDesiredResourceState",
                    value = "$none$",
                    place1 = thing.place1 + "_1",
                    place2 = thing.place2 + "_1",
                    foundation = "CoupleType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "desiredResourceStateOfCapability",
                    id = thing.place2 + "_3",
                    name = thing.value + "_desiredResourceStateOfCapability",
                    value = "$none$",
                    place1 = thing.place2,
                    place2 = thing.place2 + "_1",
                    foundation = "WholePartType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "effectMeasure",
                    id = thing.place2 + "_6",
                    name = thing.value + "_effectMeasure",
                    value = "$none$",
                    place1 = thing.place2 + "_1",
                    place2 = thing.place2 + "_4",
                    foundation = "superSubtype",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "desireMeasure",
                    id = thing.place2 + "_7",
                    name = thing.value + "_desireMeasure",
                    value = "$none$",
                    place1 = thing.place2 + "_1",
                    place2 = thing.place2 + "_5",
                    foundation = "superSubtype",
                    value_type = "$none$"
                });

                CV1_mandatory_views.Add(thing.place2, values);
            }

            //CV-4

            results =
                from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol")
                where (string)result.Parent.Attribute("SAObjMinorTypeName") == "CV-04 Capability Dependencies (DM2)"
                where (string)result.Attribute("SAObjMinorTypeName") == "Capability (DM2)"
                select new Thing
                {
                    type = "CV-04 View",
                    id = "$none$",
                    name = ((string)result.Parent.Attribute("SAObjName")).Replace("&", " And "),
                    value = ((string)result.Attribute("SAObjName")).Replace("&", " And "),
                    place1 = (string)result.Parent.Attribute("SAObjId"),
                    place2 = (string)result.Attribute("SASymIdDef"),
                    foundation = "$none$",
                    value_type = "$Capability Name$"
                };

            foreach (Thing thing in results.ToList())
            {
                if (thing.place2 == null)
                    continue;

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Resource",
                    id = thing.place2 + "_1",
                    name = thing.value + "_DesiredResourceState",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                things = things.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "desiredResourceStateOfCapability",
                    id = thing.place2 + "_3",
                    name = thing.value + "_desiredResourceStateOfCapability",
                    value = "$none$",
                    place1 = thing.place2,
                    place2 = thing.place2 + "_1",
                    foundation = "WholePartType",
                    value_type = "$none$"
                });

                tuple_types = tuple_types.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Resource",
                    id = thing.place2 + "_1",
                    name = thing.value + "_DesiredResourceState",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values2 = new List<Thing>();
                if (!CV1_optional_views.TryGetValue(thing.place2, out values2))
                    CV1_optional_views.Add(thing.place2, values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "desiredResourceStateOfCapability",
                    id = thing.place2 + "_3",
                    name = thing.value + "_desiredResourceStateOfCapability",
                    value = "$none$",
                    place1 = thing.place2,
                    place2 = thing.place2 + "_1",
                    foundation = "WholePartType",
                    value_type = "$none$"
                });

                values2 = new List<Thing>();
                if (!CV4_mandatory_views.TryGetValue(thing.place2, out values2))
                    CV4_mandatory_views.Add(thing.place2, values);
            }

            // Data Store

            things = things.GroupBy(x => x.id).Select(grp => grp.First());
            things_dic = things.ToDictionary(x => x.id, x => x);

            results =
                from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                where (string)result.Parent.Attribute("SAPrpName") == "Resources"
                where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Data Store (DM2x)"

                select new Thing
                {
                    type = "WholePartType",
                    id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity"),
                    name = "$none$",
                    value = "$none$",
                    place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                    place2 = (string)result.Attribute("SALinkIdentity"),
                    foundation = "WholePartType",
                    value_type = "$none$"
                };

            tuple_types = tuple_types.Concat(results.ToList());

            foreach (Thing thing in results)
            {
                if (!things_dic.TryGetValue(thing.place2, out value))
                {
                    values = new List<Thing>();

                    values.Add(new Thing
                    {
                        type = "Data",
                        id = thing.place2,
                        name = "$none$",
                        value = "$none$",
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = "IndividualType",
                        value_type = "$none$"
                    });

                    things = things.Concat(values);
                    things_dic.Add(values.First().id, values.First());
                }
            }

            //ARO

            results =
                   from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                   where (string)result.Parent.Attribute("SAPrpName") == "consumingActivity"
                   from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                   where (string)result3.Parent.Attribute("SAPrpName") == "Resources"
                   where (string)result.Parent.Parent.Attribute("SAObjId") == (string)result3.Parent.Parent.Attribute("SAObjId")
                   from result2 in root.Elements("Class").Elements("SADefinition")
                   where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                   from result4 in root.Elements("Class").Elements("SADefinition")
                   where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


                   select new Thing
                   {
                       type = "activityConsumesResource",
                       id = (string)result.Parent.Parent.Attribute("SAObjId") + "_2",
                       name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                       value = (string)result.Parent.Parent.Attribute("SAObjId"),
                       place1 = (string)result3.Attribute("SALinkIdentity"),
                       place2 = (string)result.Attribute("SALinkIdentity"),
                       foundation = "CoupleType",
                       value_type = "$id$"
                   };

            tuple_types = tuple_types.Concat(results);
            aro = results.GroupBy(x => (string)x.value).ToDictionary(y => y.Key, y => y.ToList());
            MergeDictionaries(OV5b_aro_mandatory_views, aro);
            aro2 = results.GroupBy(x => (string)x.value).ToDictionary(y => y.Key, y => y.ToList());
            MergeDictionaries(OV6c_aro_optional_views, aro2);


            foreach (Thing thing in results.ToList())
            {
                if (things_dic.TryGetValue(thing.place1, out value))
                {
                    values = new List<Thing>();
                    values.Add(value);
                    OV5b_aro_optional_views.Add((string)thing.value, values);
                    MergeDictionaries(OV6c_aro_optional_views, new Dictionary<string, List<Thing>>() { { (string)thing.value, values } });
                }
            }

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Parent.Attribute("SAPrpName") == "consumingActivity"
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    select new Thing
                    {
                        type = "activityConsumesResource",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "CoupleType",
                        value_type = "$none$"
                    };

            foreach (Thing thing in results.ToList())
            {
                if (aro.TryGetValue(thing.id, out values))
                    continue;

                errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: Resource\r\n");

                //values = new List<Thing>();

                //values.Add(new Thing
                //{
                //    type = "Resource",
                //    id = thing.id + "_1",
                //    name = thing.name,
                //    value = "$none$",
                //    place1 = "$none$",
                //    place2 = "$none$",
                //    foundation = "IndividualType",
                //    value_type = "$none$"
                //});

                //things = things.Concat(values);
                //things_dic.Add(values.First().id, values.First());
                //OV5b_aro_optional_views.Add(thing.id, values);

                //values = new List<Thing>();

                //values.Add(new Thing
                //{
                //    type = "Resource",
                //    id = thing.id + "_1",
                //    name = thing.name,
                //    value = "$none$",
                //    place1 = "$none$",
                //    place2 = "$none$",
                //    foundation = "IndividualType",
                //    value_type = "$none$"
                //});

                //values.Add(new Thing
                //{
                //    type = "activityConsumesResource",
                //    id = thing.id + "_2",
                //    name = "ARO",
                //    value = "$none$",
                //    place1 = thing.id + "_1",
                //    place2 = thing.place2,
                //    foundation = "CoupleType",
                //    value_type = "$none$"
                //});

                //OV6c_aro_optional_views.Add(thing.id, values);

                //values = new List<Thing>();

                //values.Add(new Thing
                //{
                //    type = "activityConsumesResource",
                //    id = thing.id + "_2",
                //    name = "ARO",
                //    value = "$none$",
                //    place1 = thing.id + "_1",
                //    place2 = thing.place2,
                //    foundation = "CoupleType",
                //    value_type = "$none$"
                //});

                //tuple_types = tuple_types.Concat(values);
                //OV5b_aro_mandatory_views.Add(thing.id, values);

            }

            results =
                   from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                   where (string)result.Parent.Attribute("SAPrpName") == "producingActivity"
                   from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                   where (string)result3.Parent.Attribute("SAPrpName") == "Resources"
                   where (string)result.Parent.Parent.Attribute("SAObjId") == (string)result3.Parent.Parent.Attribute("SAObjId")
                   from result4 in root.Elements("Class").Elements("SADefinition")
                   where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")
                   from result2 in root.Elements("Class").Elements("SADefinition")
                   where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")

                   select new Thing
                   {
                       type = "activityProducesResource",
                       id = (string)result.Parent.Parent.Attribute("SAObjId") + "_3",
                       name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                       value = (string)result.Parent.Parent.Attribute("SAObjId"),
                       place2 = (string)result3.Attribute("SALinkIdentity"),
                       place1 = (string)result.Attribute("SALinkIdentity"),
                       foundation = "CoupleType",
                       value_type = "$id$"
                   };

            tuple_types = tuple_types.Concat(results);
            aro = results.GroupBy(x => (string)x.value).ToDictionary(y => y.Key, y => y.ToList());
            MergeDictionaries(OV5b_aro_mandatory_views, aro);
            aro2 = results.GroupBy(x => (string)x.value).ToDictionary(y => y.Key, y => y.ToList());
            MergeDictionaries(OV6c_aro_optional_views, aro2);

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Parent.Attribute("SAPrpName") == "producingActivity"
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    select new Thing
                    {
                        type = "activityProducesResource",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "CoupleType",
                        value_type = "$none$"
                    };

            foreach (Thing thing in results.ToList())
            {
                if (aro.TryGetValue(thing.id, out values))
                    continue;

                errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: Resource\r\n");

                //values = new List<Thing>();

                //values.Add(new Thing
                //{
                //    type = "activityProducesResource",
                //    id = thing.id + "_3",
                //    name = "ARO",
                //    value = "$none$",
                //    place1 = thing.place2,
                //    place2 = thing.id + "_1",
                //    foundation = "CoupleType",
                //    value_type = "$none$"
                //});

                //tuple_types = tuple_types.Concat(values);

                //results_dic = new Dictionary<string, List<Thing>>();

                //results_dic.Add(thing.id, values);

                //MergeDictionaries(OV6c_aro_optional_views, results_dic);
                //MergeDictionaries(OV5b_aro_mandatory_views, results_dic);
            }

            foreach (KeyValuePair<string, List<Thing>> dicItems in OV5b_aro_mandatory_views)
            {
                values = dicItems.Value;
                values2 = values.Where(x => x.type == "activityProducesResource").ToList();
                values3 = values.Where(x => x.type == "activityConsumesResource").ToList();

                if (values2.Count == 1 && values3.Count == 1)
                {
                    value = values2.First();
                    value2 = values3.First();

                    tuple_types = tuple_types.Concat(new List<Thing>()
                                            {
                                                new Thing
                                                {
                                                    type = "OverlapType",
                                                    id = value.value+"_ARO1",
                                                    name = value.name,
                                                    value = value.value,
                                                    place1 = value.place1,
                                                    place2 = value2.place2,
                                                    foundation = "CoupleType",
                                                    value_type = "$id$"
                                                }
                                            });
                }
            }

            //activityChangesResource

            results_dic =
                    (from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty")
                     where (string)result.Attribute("SAPrpName") == "Behavior"
                     select new
                     {
                         key = (string)result.Parent.Attribute("SAObjId"),
                         value = new List<Thing> {new Thing
                                            {
                                                type = "ActivityChangesResource",
                                                id = (string)result.Parent.Attribute("SAObjId"),
                                                name = ((string)result.Parent.Attribute("SAObjName")).Replace("&", " And "),
                                                value = (string)result.Attribute("SAPrpValue"),
                                                place1 = "$none$",
                                                place2 = "$none$",
                                                foundation = "$none$",
                                                value_type = "$none$"
                                            }}
                     }).ToDictionary(a => a.key, a => a.value);

            if (results_dic.Count() > 0)
            {
                results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == "Activity"
                        from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result3.Parent.Attribute("SAPrpName") == "Resource"
                        where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                        from result2 in root.Elements("Class").Elements("SADefinition")
                        where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                        from result4 in root.Elements("Class").Elements("SADefinition")
                        where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")
                        select new Thing
                        {
                            type = (((string)(results_dic[(string)result.Parent.Parent.Attribute("SAObjId")].First().value) == "Consumes") ? "activityConsumesResource" : "activityProducesResource"),
                            id = (string)result.Parent.Parent.Attribute("SAObjId"),
                            name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                            value = "$none$",
                            place1 = (((string)(results_dic[(string)result.Parent.Parent.Attribute("SAObjId")].First().value) == "Consumes") ? (string)result3.Attribute("SALinkIdentity") : (string)result.Attribute("SALinkIdentity")),
                            place2 = (((string)(results_dic[(string)result.Parent.Parent.Attribute("SAObjId")].First().value) == "Consumes") ? (string)result.Attribute("SALinkIdentity") : (string)result3.Attribute("SALinkIdentity")),
                            foundation = "CoupleType",
                            value_type = "$none$"
                        };

                tuple_types = tuple_types.Concat(results.ToList());

                values_dic = results.ToDictionary(x => x.id, x => x);
                foreach (Thing thing in results_dic.Select(x => x.Value.First()).ToList())
                {
                    if (!values_dic.TryGetValue(thing.id, out value))
                    {
                        errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: Resource\r\n");
                    }
                }
            }

            //activityPerformedByPerformer

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Attribute("SAPrpName") == "Activity"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "Performer"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


                    select new Thing
                    {
                        type = "activityPerformedByPerformer",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result3.Attribute("SALinkIdentity"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "CoupleType",
                        value_type = "$none$"
                    };

            tuple_types = tuple_types.Concat(results.ToList());

            values_dic = results.ToDictionary(a => a.id, a => a);

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Attribute("SAPrpName") == "Activity"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "Performer"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    //from result2 in root.Elements("Class").Elements("SADefinition")
                    //from result4 in root.Elements("Class").Elements("SADefinition")
                    //where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    //where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


                    select new Thing
                    {
                        type = "activityPerformedByPerformer",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = (string)result3.Parent.Attribute("SAPrpValue"),
                        place1 = (string)result3.Attribute("SALinkIdentity"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "CoupleType",
                        value_type = "$view name$"
                    };

            values = new List<Thing>();
            values2 = new List<Thing>();

            foreach (Thing thing in results)
            {

                if (!values_dic.TryGetValue(thing.id, out value))
                {
                    //    values2.Add(thing);

                    if (!things_dic.TryGetValue(thing.place2, out value))
                    {
                        errors_list.Add(thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: Activity\r\n");
                        //    value = new Thing
                        //    {
                        //        type = "Activity",
                        //        id = thing.place2,
                        //        name = thing.name,
                        //        value = "$none$",
                        //        place1 = "$none$",
                        //        place2 = "$none$",
                        //        foundation = "IndividualType",
                        //        value_type = "$none$"
                        //    };
                        //    values.Add(value);
                        //    things_dic.Add(thing.place2, value);
                    }

                    if (!things_dic.TryGetValue(thing.place1, out value))
                    {
                        if (((string)thing.value).Contains("Service"))
                        {
                            errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: Service\r\n");
                            //        value = new Thing
                            //        {
                            //            type = "Service",
                            //            id = thing.place1,
                            //            name = thing.name,
                            //            value = "$none$",
                            //            place1 = "$none$",
                            //            place2 = "$none$",
                            //            foundation = "IndividualType",
                            //            value_type = "$none$"
                            //        };
                            //        values.Add(value);
                            //        things_dic.Add(thing.place1, value);
                        }
                        else if (((string)thing.value).Contains("System"))
                        {
                            errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: System\r\n");
                            //        value = new Thing
                            //        {
                            //            type = "System",
                            //            id = thing.place1,
                            //            name = thing.name,
                            //            value = "$none$",
                            //            place1 = "$none$",
                            //            place2 = "$none$",
                            //            foundation = "IndividualType",
                            //            value_type = "$none$"
                            //        };
                            //        values.Add(value);
                            //        things_dic.Add(thing.place1, value);
                        }
                        else
                        {
                            errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: Performer\r\n");
                            //        value = new Thing
                            //        {
                            //            type = "Performer",
                            //            id = thing.place1,
                            //            name = thing.name,
                            //            value = "$none$",
                            //            place1 = "$none$",
                            //            place2 = "$none$",
                            //            foundation = "IndividualType",
                            //            value_type = "$none$"
                            //        };
                            //        values.Add(value);
                            //        things_dic.Add(thing.place1, value);
                        }
                    }
                }
            }

            //things = things.Concat(values);

            //tuple_types = tuple_types.Concat(values2);

            //System Data Flow (DM2rx)

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Attribute("SAPrpName") == "Source"
                    where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "System Data Flow (DM2rx)"
                    from result2 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result2.Parent.Attribute("SAPrpName") == "Destination"
                    where (string)result2.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "Resources"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result2.Parent.Parent.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")

                    select new Thing
                    {
                        type = "temp",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = (string)result3.Attribute("SALinkIdentity"),
                        place1 = (string)result.Attribute("SALinkIdentity"),
                        place2 = (string)result2.Attribute("SALinkIdentity"),
                        foundation = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result3.Attribute("SALinkIdentity"),
                        value_type = "$resources$"
                    };

            //results2 = tuple_types.Where(x => x.type == "activityPerformedByPerformer");//.GroupBy(x => x.place2).Where(x => x.Count() == 1).Select(grp => grp.First());
            //values_dic = results2.GroupBy(x =>x.place2).Where(x => x.Count() == 1).ToDictionary(y => y.Key, y => y.First());

            foreach (Thing thing in results)
            {
                values = new List<Thing>();
                values2 = new List<Thing>();
                mandatory_list = new List<Thing>();
                bool needs_data = false;

                if (things_dic.TryGetValue((string)thing.value, out value2))
                {
                    if (value2.type != "Data")
                    {
                        errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory System Data Flow Element: Data\r\n");
                        continue;
                        //values2.Add(new Thing
                        //{
                        //    type = "Data",
                        //    id = thing.id + "_7",
                        //    name = thing.name,
                        //    value = "$none$",
                        //    place1 = "$none$",
                        //    place2 = "$none$",
                        //    foundation = "IndividualType",
                        //    value_type = "$none$"
                        //});

                        //things_dic.Add(thing.id + "_7", new Thing
                        //{
                        //    type = "Data",
                        //    id = thing.id + "_7",
                        //    name = thing.name,
                        //    value = "$none$",
                        //    place1 = "$none$",
                        //    place2 = "$none$",
                        //    foundation = "IndividualType",
                        //    value_type = "$none$"
                        //});

                        //needs_data = true;
                    }
                    else
                    {
                        mandatory_list.Add(value2);

                        things_dic.TryGetValue(thing.place1, out value);

                        if (value.type != "Activity")// || !values_dic.TryGetValue(thing.place1, out value2))
                        {
                            errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory System Data Flow Element: System Function\r\n");
                            continue;
                            //values2.Add(new Thing
                            //{
                            //    type = "Activity",
                            //    id = thing.id + "_1",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = "$none$",
                            //    place2 = "$none$",
                            //    foundation = "IndividualType",
                            //    value_type = "$none$"
                            //});

                            //things_dic.Add(thing.id + "_1", new Thing
                            //{
                            //    type = "Activity",
                            //    id = thing.id + "_1",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = "$none$",
                            //    place2 = "$none$",
                            //    foundation = "IndividualType",
                            //    value_type = "$none$"
                            //});

                            //values.Add(new Thing
                            //{
                            //    type = "activityProducesResource",
                            //    id = thing.id + "_3",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = thing.id + "_1",
                            //    place2 = (needs_data ? thing.id + "_7" : (string)thing.value),
                            //    foundation = "CoupleType",
                            //    value_type = "$none$"
                            //});

                            //values.Add(new Thing
                            //{
                            //    type = "activityPerformedByPerformer",
                            //    id = thing.id + "_5",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = thing.place1,
                            //    place2 = thing.id + "_1",
                            //    foundation = "CoupleType",
                            //    value_type = "$none$"
                            //});

                        }
                        else
                        {
                            values.Add(new Thing
                            {
                                type = "activityProducesResource",
                                id = thing.foundation + "_3",
                                name = thing.name,
                                value = "$none$",
                                place1 = thing.place1,
                                place2 = (needs_data ? thing.id + "_7" : (string)thing.value),
                                foundation = "CoupleType",
                                value_type = "$none$"
                            });
                        }

                        things_dic.TryGetValue(thing.place2, out value);

                        if (value.type != "Activity")// || !values_dic.TryGetValue(thing.place2, out value2))
                        {
                            errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory System Data Flow Element: System Function\r\n");
                            continue;
                            //values2.Add(new Thing
                            //{
                            //    type = "Activity",
                            //    id = thing.id + "_2",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = "$none$",
                            //    place2 = "$none$",
                            //    foundation = "IndividualType",
                            //    value_type = "$none$"
                            //});

                            //things_dic.Add(thing.id + "_2", new Thing
                            //{
                            //    type = "Activity",
                            //    id = thing.id + "_2",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = "$none$",
                            //    place2 = "$none$",
                            //    foundation = "IndividualType",
                            //    value_type = "$none$"
                            //});

                            //values.Add(new Thing
                            //{
                            //    type = "activityConsumesResource",
                            //    id = thing.id + "_4",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = (needs_data ? thing.id + "_7" : (string)thing.value),
                            //    place2 = thing.id + "_2",
                            //    foundation = "CoupleType",
                            //    value_type = "$none$"
                            //});

                            //values.Add(new Thing
                            //{
                            //    type = "activityPerformedByPerformer",
                            //    id = thing.id + "_6",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = thing.place2,
                            //    place2 = thing.id + "_2",
                            //    foundation = "CoupleType",
                            //    value_type = "$none$"
                            //});
                        }
                        else
                        {
                            values.Add(new Thing
                            {
                                type = "activityConsumesResource",
                                id = thing.foundation + "_4",
                                name = thing.name,
                                value = "$none$",
                                place1 = (needs_data ? thing.id + "_7" : (string)thing.value),
                                place2 = thing.place2,
                                foundation = "CoupleType",
                                value_type = "$none$"
                            });
                        }

                        mandatory_list.AddRange(values);
                        if (values2.Count > 0)
                            mandatory_list.AddRange(values2);

                        results_dic = new Dictionary<string, List<Thing>>();
                        results_dic.Add(thing.id, mandatory_list);
                        MergeDictionaries(needline_mandatory_views, results_dic);

                        if (values2.Count > 0)
                            things = things.Concat(values2);

                        tuple_types = tuple_types.Concat(values);

                        tuple_types = tuple_types.Concat(new List<Thing>()
                                            {
                                                new Thing
                                                {
                                                    type = "OverlapType",
                                                    id = thing.foundation+"_DL1",
                                                    name = thing.name,
                                                    value = thing.id,
                                                    place1 = thing.place1,
                                                    place2 = thing.place2,
                                                    foundation = "CoupleType",
                                                    value_type = "$id$"
                                                }
                                            });

                    }

                }
            }

            //Service Data Flow (DM2rx)

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Attribute("SAPrpName") == "Source"
                    where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Service Data Flow (DM2rx)"
                    from result2 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result2.Parent.Attribute("SAPrpName") == "Destination"
                    where (string)result2.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "Resources"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result2.Parent.Parent.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")

                    select new Thing
                    {
                        type = "temp",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = (string)result3.Attribute("SALinkIdentity"),
                        place1 = (string)result.Attribute("SALinkIdentity"),
                        place2 = (string)result2.Attribute("SALinkIdentity"),
                        foundation = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result3.Attribute("SALinkIdentity"),
                        value_type = "$resources$"
                    };

            //results2 = tuple_types.Where(x => x.type == "activityPerformedByPerformer");//.GroupBy(x => x.place2).Where(x => x.Count() == 1).Select(grp => grp.First());
            //values_dic = results2.GroupBy(x =>x.place2).Where(x => x.Count() == 1).ToDictionary(y => y.Key, y => y.First());

            foreach (Thing thing in results)
            {
                values = new List<Thing>();
                values2 = new List<Thing>();
                mandatory_list = new List<Thing>();
                bool needs_data = false;

                if (things_dic.TryGetValue((string)thing.value, out value2))
                {
                    if (value2.type != "Data")
                    {
                        errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Service Data Flow Element: Data\r\n");
                        continue;
                        //values2.Add(new Thing
                        //{
                        //    type = "Data",
                        //    id = thing.id + "_7",
                        //    name = thing.name,
                        //    value = "$none$",
                        //    place1 = "$none$",
                        //    place2 = "$none$",
                        //    foundation = "IndividualType",
                        //    value_type = "$none$"
                        //});

                        //things_dic.Add(thing.id + "_7", new Thing
                        //{
                        //    type = "Data",
                        //    id = thing.id + "_7",
                        //    name = thing.name,
                        //    value = "$none$",
                        //    place1 = "$none$",
                        //    place2 = "$none$",
                        //    foundation = "IndividualType",
                        //    value_type = "$none$"
                        //});

                        //needs_data = true;
                    }
                    else
                    {
                        mandatory_list.Add(value2);

                        things_dic.TryGetValue(thing.place1, out value);

                        if (value.type != "Activity")// || !values_dic.TryGetValue(thing.place1, out value2))
                        {
                            errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Service Data Flow Element: System Function\r\n");
                            continue;
                            //values2.Add(new Thing
                            //{
                            //    type = "Activity",
                            //    id = thing.id + "_1",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = "$none$",
                            //    place2 = "$none$",
                            //    foundation = "IndividualType",
                            //    value_type = "$none$"
                            //});

                            //things_dic.Add(thing.id + "_1", new Thing
                            //{
                            //    type = "Activity",
                            //    id = thing.id + "_1",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = "$none$",
                            //    place2 = "$none$",
                            //    foundation = "IndividualType",
                            //    value_type = "$none$"
                            //});

                            //values.Add(new Thing
                            //{
                            //    type = "activityProducesResource",
                            //    id = thing.id + "_3",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = thing.id + "_1",
                            //    place2 = (needs_data ? thing.id + "_7" : (string)thing.value),
                            //    foundation = "CoupleType",
                            //    value_type = "$none$"
                            //});

                            //values.Add(new Thing
                            //{
                            //    type = "activityPerformedByPerformer",
                            //    id = thing.id + "_5",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = thing.place1,
                            //    place2 = thing.id + "_1",
                            //    foundation = "CoupleType",
                            //    value_type = "$none$"
                            //});

                        }
                        else
                        {
                            values.Add(new Thing
                            {
                                type = "activityProducesResource",
                                id = thing.foundation + "_3",
                                name = thing.name,
                                value = "$none$",
                                place1 = thing.place1,
                                place2 = (needs_data ? thing.id + "_7" : (string)thing.value),
                                foundation = "CoupleType",
                                value_type = "$none$"
                            });
                        }

                        things_dic.TryGetValue(thing.place2, out value);

                        if (value.type != "Activity")// || !values_dic.TryGetValue(thing.place2, out value2))
                        {
                            errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Service Data Flow Element: System Function\r\n");
                            continue;
                            //values2.Add(new Thing
                            //{
                            //    type = "Activity",
                            //    id = thing.id + "_2",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = "$none$",
                            //    place2 = "$none$",
                            //    foundation = "IndividualType",
                            //    value_type = "$none$"
                            //});

                            //things_dic.Add(thing.id + "_2", new Thing
                            //{
                            //    type = "Activity",
                            //    id = thing.id + "_2",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = "$none$",
                            //    place2 = "$none$",
                            //    foundation = "IndividualType",
                            //    value_type = "$none$"
                            //});

                            //values.Add(new Thing
                            //{
                            //    type = "activityConsumesResource",
                            //    id = thing.id + "_4",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = (needs_data ? thing.id + "_7" : (string)thing.value),
                            //    place2 = thing.id + "_2",
                            //    foundation = "CoupleType",
                            //    value_type = "$none$"
                            //});

                            //values.Add(new Thing
                            //{
                            //    type = "activityPerformedByPerformer",
                            //    id = thing.id + "_6",
                            //    name = thing.name,
                            //    value = "$none$",
                            //    place1 = thing.place2,
                            //    place2 = thing.id + "_2",
                            //    foundation = "CoupleType",
                            //    value_type = "$none$"
                            //});
                        }
                        else
                        {
                            values.Add(new Thing
                            {
                                type = "activityConsumesResource",
                                id = thing.foundation + "_4",
                                name = thing.name,
                                value = "$none$",
                                place1 = (needs_data ? thing.id + "_7" : (string)thing.value),
                                place2 = thing.place2,
                                foundation = "CoupleType",
                                value_type = "$none$"
                            });
                        }

                        mandatory_list.AddRange(values);
                        if (values2.Count > 0)
                            mandatory_list.AddRange(values2);

                        results_dic = new Dictionary<string, List<Thing>>();
                        results_dic.Add(thing.id, mandatory_list);
                        MergeDictionaries(needline_mandatory_views, results_dic);

                        if (values2.Count > 0)
                            things = things.Concat(values2);

                        tuple_types = tuple_types.Concat(values);

                        tuple_types = tuple_types.Concat(new List<Thing>()
                                            {
                                                new Thing
                                                {
                                                    type = "OverlapType",
                                                    id = thing.foundation+"_DL1",
                                                    name = thing.name,
                                                    value = thing.id,
                                                    place1 = thing.place1,
                                                    place2 = thing.place2,
                                                    foundation = "CoupleType",
                                                    value_type = "$id$"
                                                }
                                            });
                    }

                }
            }

            //Needlines

            //values = new List<Thing>();

            //values_dic = things_dic.Where(x => x.Value.type == "Resource" || x.Value.type == "Data").ToDictionary(p => p.Key, p => p.Value);
            ////var acr3 = tuple_types.Where(x => x.type == "activityConsumesResource").Where(x => temp_dic.ContainsKey(x.place1)).GroupBy(x => x.place2).Where(x => x.Count() == 1).Select(grp => grp.First());
            //values_dic2 = tuple_types.Where(x => x.type == "activityConsumesResource").Where(x => values_dic.ContainsKey(x.place1)).GroupBy(x => x.place2).Where(x => x.Count() == 1).ToDictionary(y => y.Key, y => y.First());
            //results = tuple_types.Where(x => x.type == "activityPerformedByPerformer").GroupBy(x =>x.place2).Where(x => x.Count() == 1).Select(grp => grp.First());
            ////var app4 = app3.GroupBy(x =>x.place1).Where(x => x.Count() == 1).ToDictionary(y => y.Key, y => y.First());

            //values_dic.Clear();
            //foreach (Thing rela in results)
            //{
            //    if (values_dic2.TryGetValue(rela.place2, out value))
            //    {
            //        if(!values_dic.Remove(rela.place1))
            //            values_dic.Add(rela.place1, rela);
            //    }

            //}

            //values_dic.Clear();
            //foreach (Thing rela in acr3)
            //{
            //    if (app4.TryGetValue(rela.place2, out value))
            //    {
            //        values_dic.Add(value.place1, value);
            //    }

            //}

            results_dic2 = new Dictionary<string, List<Thing>>();
            results_dic3 = new Dictionary<string, List<Thing>>();
            results_dic = tuple_types.Where(x => x.type == "activityPerformedByPerformer").GroupBy(x => x.place1).ToDictionary(x => x.Key, x => x.ToList());
            aro = tuple_types.Where(x => x.type == "activityConsumesResource").GroupBy(x => x.place2).ToDictionary(x => x.Key, x => x.ToList());

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") != "System Exchange (DM2rx)" && (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") != "Operational Exchange (DM2rx)"
                        && (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") != "System Data Flow (DM2rx)" && (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") != "Service Data Flow (DM2rx)"
                    where (string)result.Parent.Attribute("SAPrpName") == "performerTarget" || (string)result.Parent.Attribute("SAPrpName") == "Target" || (string)result.Parent.Attribute("SAPrpName") == "Destination"
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    select new Thing
                    {
                        type = "Resource Flow",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = (string)result.Parent.Attribute("SAPrpName") + "_" + (string)result.Parent.Parent.Attribute("SAObjMinorTypeName"),
                        place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "CoupleType",
                        value_type = "$none$"
                    };

            foreach (Thing thing in results.ToList())
            {
                if (results_dic.TryGetValue(thing.place2, out values))
                {
                    values2 = new List<Thing>();
                    values4 = new List<Thing>();
                    add = true;
                    foreach (Thing app in values)
                    {
                        if (aro.TryGetValue(app.place2, out values3))
                        {
                            add = false;
                            //break;
                            values4.Add(app);
                            values2.AddRange(values3);
                        }
                    }
                    if (add)
                        errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: activityConsumesResource\r\n");
                }
                else
                {
                    errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: activityPerformedByPerformer\r\n");
                }

                results_dic3.Add(thing.id, values4);
                results_dic2.Add(thing.id, values2);

                //if (values_dic.TryGetValue(thing.id, out value))
                //    continue;

                //values = new List<Thing>();

                //values.Add(new Thing
                //    {
                //        type = "Activity",
                //        id = thing.id + "_1",
                //        name = thing.name,
                //        value = "$none$",
                //        place1 = "$none$",
                //        place2 = "$none$",
                //        foundation = "IndividualType",
                //        value_type = "$none$"
                //    });
                //values.Add(new Thing
                //{
                //    type = (((string)thing.value).Contains("System") || ((string)thing.value).Contains("Service") ? "Data" : "Resource"),
                //    id = thing.id + "_2",
                //    name = (((string)thing.value).Contains("performerTarget") ? "Needline" : "SF"),
                //    value = "$none$",
                //    place1 = "$none$",
                //    place2 = "$none$",
                //    foundation = "IndividualType",
                //    value_type = "$none$"
                //});

                //things = things.Concat(values);

                //values = new List<Thing>();

                //values.Add(new Thing
                //{
                //    type = "activityPerformedByPerformer",
                //    id = thing.id,
                //    name = thing.name,
                //    value = "$none$",
                //    place1 = thing.place2,
                //    place2 = thing.id + "_1",
                //    foundation = "CoupleType",
                //    value_type = "$none$"
                //});

                //values.Add(new Thing
                //{
                //    type = "activityConsumesResource",
                //    id = thing.id + "_3",
                //    name = (((string)thing.value).Contains("performerTarget") ? "Needline" : "SF"),
                //    value = "$none$",
                //    place1 = thing.id + "_2",
                //    place2 = thing.id + "_1",
                //    foundation = "CoupleType",
                //    value_type = "$none$"
                //});

                //tuple_types = tuple_types.Concat(values);

                //values = new List<Thing>();

                //values.Add(new Thing
                //{
                //    type = (((string)thing.value).Contains("System") || ((string)thing.value).Contains("Service") ? "Data" : "Resource"),
                //    id = thing.id + "_2",
                //    name = (((string)thing.value).Contains("performerTarget") ? "Needline" : "SF"),
                //    value = "$none$",
                //    place1 = "$none$",
                //    place2 = "$none$",
                //    foundation = "IndividualType",
                //    value_type = "$none$"
                //});

                //if (!((string)thing.value).Contains("Service") && !((string)thing.value).Contains("System"))
                //{
                //    needline_optional_views.Add(thing.id, values);
                //    values = new List<Thing>();
                //}

                //values.Add(new Thing
                //{
                //    type = "activityPerformedByPerformer",
                //    id = thing.id,
                //    name = thing.name,
                //    value = "$none$",
                //    place1 = thing.place2,
                //    place2 = thing.id + "_1",
                //    foundation = "CoupleType",
                //    value_type = "$none$"
                //});

                //values.Add(new Thing
                //{
                //    type = "activityConsumesResource",
                //    id = thing.id + "_3",
                //    name = (((string)thing.value).Contains("performerTarget") ? "Needline" : "SF"),
                //    value = "$none$",
                //    place1 = thing.id + "_2",
                //    place2 = thing.id + "_1",
                //    foundation = "CoupleType",
                //    value_type = "$none$"
                //});

                //values.Add(new Thing
                //{
                //    type = "Activity",
                //    id = thing.id + "_1",
                //    name = thing.name,
                //    value = "$none$",
                //    place1 = "$none$",
                //    place2 = "$none$",
                //    foundation = "IndividualType",
                //    value_type = "$none$"
                //});

                //needline_mandatory_views.Add(thing.id, values);
            }

            if (results_dic2.Count > 0)
            {
                aro2 = tuple_types.Where(x => x.type == "activityProducesResource").GroupBy(x => x.place1).ToDictionary(x => x.Key, x => x.ToList());

                results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") != "System Exchange (DM2rx)" && (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") != "Operational Exchange (DM2rx)"
                            && (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") != "System Data Flow (DM2rx)" && (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") != "Service Data Flow (DM2rx)"
                        where (string)result.Parent.Attribute("SAPrpName") == "performerSource" || (string)result.Parent.Attribute("SAPrpName") == "Source"
                        from result2 in root.Elements("Class").Elements("SADefinition")
                        where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                        select new Thing
                        {
                            type = "Resource Flow",
                            id = (string)result.Parent.Parent.Attribute("SAObjId"),
                            name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                            value = (string)result.Parent.Attribute("SAPrpName") + "_" + (string)result.Parent.Parent.Attribute("SAObjMinorTypeName"),
                            place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place2 = (string)result.Attribute("SALinkIdentity"),
                            foundation = "CoupleType",
                            value_type = "$none$"
                        };

                foreach (Thing thing in results.ToList())
                {
                    results_dic2.TryGetValue(thing.id, out values4);
                    if (values4 == null)
                        continue;
                    values_dic = values4.ToDictionary(x => "_" + x.id.Split('_')[1], x => x);
                    if (results_dic.TryGetValue(thing.place2, out values))
                    {
                        add = true;
                        values2 = new List<Thing>();
                        values7 = new List<Thing>();
                        foreach (Thing app in values)
                        {
                            if (aro2.TryGetValue(app.place2, out values3))
                            {
                                foreach (Thing apr in values3)
                                {
                                    if (values_dic.TryGetValue("_" + apr.id.Split('_')[1], out value))
                                    {
                                        add = false;
                                        //break;
                                        values2.Add(value);
                                        values7.Add(things_dic[value.place1]);
                                        values2.Add(things_dic[value.place2]);
                                        values2.Add(app);
                                        value2 = things_dic[app.place1];
                                        if (value2.type == "Performer")
                                            values7.Add(value2);
                                        else
                                            values2.Add(value2);
                                        values2.Add(apr);
                                        values2.Add(things_dic[apr.place1]);
                                        results_dic3.TryGetValue(thing.id, out values5);
                                        values6 = values5.Where(x => x.place2 == value.place2).ToList();
                                        values2.AddRange(values6);
                                        foreach (Thing app2 in values6)
                                        {
                                            value2 = things_dic[app2.place1];
                                            if (value2.type == "Performer")
                                                values7.Add(value2);
                                            else
                                                values2.Add(value2);

                                            tuple_types = tuple_types.Concat(new List<Thing>()
                                            {
                                                new Thing
                                                {
                                                    type = "OverlapType",
                                                    id = thing.id+"_FL1",
                                                    name = thing.name,
                                                    value = thing.id,
                                                    place1 = app.place1,
                                                    place2 = app2.place1,
                                                    foundation = "CoupleType",
                                                    value_type = "$id$"
                                                }
                                            });
                                        }
                                    }
                                }
                            }
                        }
                        if (add)
                            errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: activityProducesResource\r\n");
                    }
                    else
                    {
                        errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: activityPerformedByPerformer\r\n");
                    }

                    if (values2.Count > 0)
                        needline_mandatory_views.Add(thing.id, values2);

                    if (values7.Count > 0)
                        needline_optional_views.Add(thing.id, values7);

                    //results_dic2 = new Dictionary<string, List<Thing>>();

                    //results_dic2.Add(thing.id, values2);

                    //MergeDictionaries(needline_mandatory_views, results_dic2);

                    //values = new List<Thing>();

                    //values.Add(new Thing
                    //{
                    //    type = "Activity",
                    //    id = thing.id + "_4",
                    //    name = thing.name,
                    //    value = "$none$",
                    //    place1 = "$none$",
                    //    place2 = "$none$",
                    //    foundation = "IndividualType",
                    //    value_type = "$none$"
                    //});

                    //things = things.Concat(values);

                    //values = new List<Thing>();

                    //values.Add(new Thing
                    //{
                    //    type = "activityProducesResource",
                    //    id = thing.id + "_5",
                    //    name = (((string)thing.value).Contains("performerSource") ? "Needline" : "SF"),
                    //    value = "$none$",
                    //    place1 = thing.id + "_4",
                    //    place2 = thing.id + "_2",
                    //    foundation = "CoupleType",
                    //    value_type = "$none$"
                    //});

                    //values.Add(new Thing
                    //{
                    //    type = "activityPerformedByPerformer",
                    //    id = thing.id + "_6",
                    //    name = thing.name,
                    //    value = "$none$",
                    //    place1 = thing.place2,
                    //    place2 = thing.id + "_4",
                    //    foundation = "CoupleType",
                    //    value_type = "$none$"
                    //});

                    //tuple_types = tuple_types.Concat(values);

                    //values = new List<Thing>();

                    //values.Add(new Thing
                    //{
                    //    type = "activityProducesResource",
                    //    id = thing.id + "_5",
                    //    name = (((string)thing.value).Contains("performerSource") ? "Needline" : "SF"),
                    //    value = "$none$",
                    //    place1 = thing.id + "_4",
                    //    place2 = thing.id + "_2",
                    //    foundation = "CoupleType",
                    //    value_type = "$none$"
                    //});

                    //values.Add(new Thing
                    //{
                    //    type = "Activity",
                    //    id = thing.id + "_4",
                    //    name = thing.name,
                    //    value = "$none$",
                    //    place1 = "$none$",
                    //    place2 = "$none$",
                    //    foundation = "IndividualType",
                    //    value_type = "$none$"
                    //});

                    //values.Add(new Thing
                    //{
                    //    type = "activityPerformedByPerformer",
                    //    id = thing.id + "_6",
                    //    name = thing.name,
                    //    value = "$none$",
                    //    place1 = thing.place2,
                    //    place2 = thing.id + "_4",
                    //    foundation = "CoupleType",
                    //    value_type = "$none$"
                    //});

                    //results_dic = new Dictionary<string, List<Thing>>();

                    //results_dic.Add(thing.id, values);

                    //MergeDictionaries(needline_mandatory_views, results_dic);
                }
            }
            ////Supports

            //results =
            //        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
            //        from result2 in root.Elements("Class").Elements("SADefinition")
            //        where (string)result.Parent.Attribute("SAPrpName") == "SupportedBy"
            //        where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
            //        select new Thing
            //        {
            //            type = "activityPerformedByPerformer",
            //            id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity"),
            //            name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
            //            value = "$none$",
            //            place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
            //            place2 = (string)result.Attribute("SALinkIdentity"),
            //            foundation = "CoupleType",
            //            value_type = "$none$"
            //        };

            //foreach (Thing thing in results.ToList())
            //{
            //    values = new List<Thing>();

            //    values.Add(new Thing
            //    {
            //        type = "Activity",
            //        id = thing.id + "_2",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "Resource",
            //        id = thing.id + "_3",
            //        name = "Support",
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });

            //    things = things.Concat(values);

            //    values = new List<Thing>();

            //    values.Add(new Thing
            //    {
            //        type = "activityPerformedByPerformer",
            //        id = thing.id + "_1",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = thing.id,
            //        place2 = thing.id + "_2",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "activityConsumesResource",
            //        id = thing.id + "_4",
            //        name = "Support",
            //        value = "$none$",
            //        place1 = thing.id + "_3",
            //        place2 = thing.id + "_2",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    tuple_types = tuple_types.Concat(values);

            //    values = new List<Thing>();

            //    values.Add(new Thing
            //    {
            //        type = "Resource",
            //        id = thing.id + "_3",
            //        name = "Support",
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });
            //    if (!OV2_support_optional_views.ContainsKey(thing.id))
            //        OV2_support_optional_views.Add(thing.id, values);

            //    values = new List<Thing>();

            //    values.Add(new Thing
            //    {
            //        type = "activityPerformedByPerformer",
            //        id = thing.id + "_1",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = thing.id,
            //        place2 = thing.id + "_2",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "activityConsumesResource",
            //        id = thing.id + "_4",
            //        name = "Support",
            //        value = "$none$",
            //        place1 = thing.id + "_3",
            //        place2 = thing.id + "_2",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "Activity",
            //        id = thing.id + "_2",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });
            //    if (!OV2_support_mandatory_views.ContainsKey(thing.id))
            //        OV2_support_mandatory_views.Add(thing.id, values);

            //    values = new List<Thing>();

            //    values.Add(new Thing
            //    {
            //        type = "activityPerformedByPerformer",
            //        id = thing.id + "_1",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = thing.id,
            //        place2 = thing.id + "_2",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "activityConsumesResource",
            //        id = thing.id + "_4",
            //        name = "Support",
            //        value = "$none$",
            //        place1 = thing.id + "_3",
            //        place2 = thing.id + "_2",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "Activity",
            //        id = thing.id + "_2",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "Resource",
            //        id = thing.id + "_3",
            //        name = "Support",
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });
            //    if (!OV4_support_optional_views.ContainsKey(thing.id))
            //        OV4_support_optional_views.Add(thing.id, values);
            //}

            //results =
            //        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
            //        from result2 in root.Elements("Class").Elements("SADefinition")
            //        where (string)result.Parent.Attribute("SAPrpName") == "Supports"
            //        where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
            //        select new Thing
            //        {
            //            type = "activityPerformedByPerformer",
            //            id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity"),
            //            name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
            //            value = "$none$",
            //            place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
            //            place2 = (string)result.Attribute("SALinkIdentity"),
            //            foundation = "CoupleType",
            //            value_type = "$none$"
            //        };

            //foreach (Thing thing in results.ToList())
            //{
            //    values = new List<Thing>();

            //    values.Add(new Thing
            //    {
            //        type = "Activity",
            //        id = thing.id + "_5",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });

            //    things = things.Concat(values);

            //    values = new List<Thing>();

            //    values.Add(new Thing
            //    {
            //        type = "activityProducesResource",
            //        id = thing.id + "_6",
            //        name = "Support",
            //        value = "$none$",
            //        place1 = thing.id + "_5",
            //        place2 = thing.place2 + thing.place1 + "_3",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "activityPerformedByPerformer",
            //        id = thing.id + "_1",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = thing.id,
            //        place2 = thing.id + "_5",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    tuple_types = tuple_types.Concat(values);

            //    values = new List<Thing>();

            //    values.Add(new Thing
            //    {
            //        type = "activityProducesResource",
            //        id = thing.id + "_6",
            //        name = "Support",
            //        value = "$none$",
            //        place1 = thing.id + "_5",
            //        place2 = thing.place2 + thing.place1 + "_3",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "Activity",
            //        id = thing.id + "_5",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });

            //    values.Add(new Thing
            //    {
            //        type = "activityPerformedByPerformer",
            //        id = thing.id + "_1",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = thing.id,
            //        place2 = thing.id + "_5",
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    if (!OV4_support_optional_views_2.ContainsKey(thing.id))
            //        OV4_support_optional_views_2.Add(thing.id, values);

            //    if (!OV2_support_mandatory_views_2.ContainsKey(thing.id))
            //        OV2_support_mandatory_views_2.Add(thing.id, values);

            //}

            //MergeDictionaries(OV4_support_optional_views, OV4_support_optional_views_2);

            //MergeDictionaries(OV2_support_mandatory_views, OV2_support_mandatory_views_2);

            //tuple_types = tuple_types.Distinct();

            //things = things.Distinct();

            //Constraint

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty")
                    //where (string)result.Parent.Attribute("SAObjMinorTypeName") != "Relationship"
                    where (string)result.Attribute("SAPrpName") == "To Cardinality"

                    select new Thing
                    {
                        type = "Rule",
                        id = (string)result.Parent.Attribute("SAObjId"),
                        name = (string)result.Attribute("SAPrpValue"),
                        value = "$none$",
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = "IndividualType",
                        value_type = "$none$"
                    };

            things = things.Concat(results.ToList());

            //DIV-2/3 Relationship

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Constraint"
                    where (string)result.Parent.Attribute("SAPrpName") == "From Table"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "To Table"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result5 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result5.Parent.Attribute("SAPrpName") == "Foreign Keys and Roles"
                    where (string)result5.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result7 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty")
                    where (string)result7.Attribute("SAPrpName") == "Identifying"
                    where (string)result7.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")
                    from result6 in root.Elements("Class").Elements("SADefinition")
                    where (string)result5.Attribute("SALinkIdentity") == (string)result6.Attribute("SAObjId")

                    select new Thing
                    {
                        type = (string)result7.Attribute("SAPrpValue"),
                        id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result5.Attribute("SALinkIdentity"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = (string)result5.Attribute("SALinkIdentity"),
                        place1 = (string)result.Attribute("SALinkIdentity"),
                        place2 = (string)result3.Attribute("SALinkIdentity"),
                        foundation = (string)result.Parent.Parent.Attribute("SAObjId"),
                        value_type = "$FK ID$"
                    };

            values3 = results.ToList();
            values_dic = values3.GroupBy(x => x.foundation).Select(grp => grp.First()).ToDictionary(x => x.foundation, x => x);

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Constraint" || (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Relationship"
                    where (string)result.Parent.Attribute("SAPrpName") == "From Table" || (string)result.Parent.Attribute("SAPrpName") == "From Entity"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "To Table" || (string)result3.Parent.Attribute("SAPrpName") == "To Entity"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")
                    from result7 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty")
                    where (string)result7.Attribute("SAPrpName") == "Identifying"
                    where (string)result7.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")

                    select new Thing
                    {
                        type = (string)result7.Attribute("SAPrpValue"),
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result.Attribute("SALinkIdentity"),
                        place2 = (string)result3.Attribute("SALinkIdentity"),
                        foundation = "$none$",
                        value_type = "$PK ID$"
                    };

            foreach (Thing thing in results)
            {
                if (!values_dic.TryGetValue(thing.id, out value))
                    values3.Add(thing);
            }

            //values_dic = values3.GroupBy(x => x.foundation).Select(grp => grp.First()).ToDictionary(x => x.foundation, x => x);

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Non-specific Relation"
                    where (string)result.Parent.Attribute("SAPrpName") == "From Table" || (string)result.Parent.Attribute("SAPrpName") == "From Entity"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "To Table" || (string)result3.Parent.Attribute("SAPrpName") == "To Entity"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")

                    select new Thing
                    {
                        type = "Non-specific",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result.Attribute("SALinkIdentity"),
                        place2 = (string)result3.Attribute("SALinkIdentity"),
                        foundation = "$none$",
                        value_type = "$PK ID$"
                    };

            foreach (Thing thing in results)
            {
                //if (!values_dic.TryGetValue(thing.id, out value))
                values3.Add(thing);
            }

            foreach (Thing thing in values3)
            {
                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Activity",
                    id = thing.id + "_2",
                    name = thing.name,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "Rule",
                    id = thing.id + "_73",
                    name = (thing.type == "T" ? "Identifying" : (thing.type == "F" ? "Non-Identifying" : thing.type)),
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                things = things.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "activityPerformedByPerformer",
                    id = thing.id + "_1",
                    name = thing.name,
                    value = "$none$",
                    place1 = thing.place1,
                    place2 = thing.id + "_2",
                    foundation = "CoupleType",
                    value_type = "$none$"
                });

                if ((string)thing.value == "$none$")
                {
                    values2 = new List<Thing>();

                    values2.Add(new Thing
                    {
                        type = "Data",
                        id = thing.id + "_9",
                        name = thing.name,
                        value = "$none$",
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = "IndividualType",
                        value_type = "$none$"
                    });

                    things = things.Concat(values2);

                    if (thing.foundation == "$none$")
                    {
                        if (!DIV2_3_mandatory.ContainsKey(thing.id))
                            DIV2_3_mandatory.Add(thing.id, values2);
                    }
                    else
                    {
                        if (!DIV2_3_mandatory.ContainsKey(thing.foundation))
                            DIV2_3_mandatory.Add(thing.foundation, values2);
                    }

                    values.Add(new Thing
                    {
                        type = "activityProducesResource",
                        id = thing.id + "_3",
                        name = thing.name,
                        value = "$none$",
                        place2 = thing.id + "_9",
                        place1 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }
                else
                {
                    values.Add(new Thing
                    {
                        type = "activityProducesResource",
                        id = thing.id + "_3",
                        name = thing.name,
                        value = "$none$",
                        place2 = (string)thing.value,
                        place1 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }

                if (thing.foundation == "$none$")
                {
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_7",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.id,
                        place2 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });

                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_72",
                        name = thing.type,
                        value = "$none$",
                        place1 = thing.id + "_73",
                        place2 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }
                else
                {
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_7",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.foundation,
                        place2 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });

                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_72",
                        name = thing.type,
                        value = "$none$",
                        place1 = thing.id + "_73",
                        place2 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }

                tuple_types = tuple_types.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "activityPerformedByPerformer",
                    id = thing.id + "_1",
                    name = thing.name,
                    value = "$none$",
                    place1 = thing.place1,
                    place2 = thing.id + "_2",
                    foundation = "CoupleType",
                    value_type = "$none$"
                });

                if ((string)thing.value == "$none$")
                {
                    //    values.Add(new Thing
                    //    {
                    //        type = "Data",
                    //        id = thing.id + "_9",
                    //        name = thing.name,
                    //        value = "$none$",
                    //        place1 = "$none$",
                    //        place2 = "$none$",
                    //        foundation = "IndividualType",
                    //        value_type = "$none$"
                    //    });

                    values.Add(new Thing
                    {
                        type = "activityProducesResource",
                        id = thing.id + "_3",
                        name = thing.name,
                        value = "$none$",
                        place2 = thing.id + "_9",
                        place1 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }
                else
                {
                    values.Add(new Thing
                    {
                        type = "activityProducesResource",
                        id = thing.id + "_3",
                        name = thing.name,
                        value = "$none$",
                        place2 = (string)thing.value,
                        place1 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }

                if (thing.foundation == "$none$")
                {
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_7",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.id,
                        place2 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });

                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_72",
                        name = thing.type,
                        value = "$none$",
                        place1 = thing.id + "_73",
                        place2 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }
                else
                {
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_7",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.foundation,
                        place2 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });

                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_72",
                        name = thing.type,
                        value = "$none$",
                        place1 = thing.id + "_73",
                        place2 = thing.id + "_2",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }

                values.Add(new Thing
                {
                    type = "Activity",
                    id = thing.id + "_2",
                    name = thing.name,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "Rule",
                    id = thing.id + "_73",
                    name = (thing.type == "T" ? "Identifying" : (thing.type == "F" ? "Non-Identifying" : thing.type)),
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                if (thing.foundation == "$none$")
                {
                    if (!DIV2_3_optional.ContainsKey(thing.id))
                        DIV2_3_optional.Add(thing.id, values);
                }
                else
                {
                    if (!DIV2_3_optional.ContainsKey(thing.foundation))
                        DIV2_3_optional.Add(thing.foundation, values);
                }
            }

            foreach (Thing thing in values3)
            {
                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Activity",
                    id = thing.id + "_4",
                    name = thing.name,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                things = things.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "activityPerformedByPerformer",
                    id = thing.id + "_5",
                    name = thing.name,
                    value = "$none$",
                    place1 = thing.place2,
                    place2 = thing.id + "_4",
                    foundation = "CoupleType",
                    value_type = "$none$"
                });

                if ((string)thing.value == "$none$")
                {
                    //values2 = new List<Thing>();

                    //values2.Add(new Thing
                    //{
                    //    type = "Data",
                    //    id = thing.id + "_9",
                    //    name = "Support",
                    //    value = "$none$",
                    //    place1 = "$none$",
                    //    place2 = "$none$",
                    //    foundation = "IndividualType",
                    //    value_type = "$none$"
                    //});

                    //things = things.Concat(values2);

                    values.Add(new Thing
                    {
                        type = "activityConsumesResource",
                        id = thing.id + "_6",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.id + "_9",
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }
                else
                {
                    values.Add(new Thing
                    {
                        type = "activityConsumesResource",
                        id = thing.id + "_6",
                        name = thing.name,
                        value = "$none$",
                        place1 = (string)thing.value,
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }

                if (thing.foundation == "$none$")
                {
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_8",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.id,
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });

                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_82",
                        name = thing.type,
                        value = "$none$",
                        place1 = thing.id + "_73",
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }
                else
                {
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_8",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.foundation,
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });

                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_82",
                        name = thing.type,
                        value = "$none$",
                        place1 = thing.id + "_73",
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }

                tuple_types = tuple_types.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "activityPerformedByPerformer",
                    id = thing.id + "_5",
                    name = thing.name,
                    value = "$none$",
                    place1 = thing.place2,
                    place2 = thing.id + "_4",
                    foundation = "CoupleType",
                    value_type = "$none$"
                });

                if ((string)thing.value == "$none$")
                {
                    //values.Add(new Thing
                    //{
                    //    type = "Data",
                    //    id = thing.id + "_9",
                    //    name = "Support",
                    //    value = "$none$",
                    //    place1 = "$none$",
                    //    place2 = "$none$",
                    //    foundation = "IndividualType",
                    //    value_type = "$none$"
                    //});

                    values.Add(new Thing
                    {
                        type = "activityConsumesResource",
                        id = thing.id + "_6",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.id + "_9",
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }
                else
                {
                    values.Add(new Thing
                    {
                        type = "activityConsumesResource",
                        id = thing.id + "_6",
                        name = thing.name,
                        value = "$none$",
                        place1 = (string)thing.value,
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }

                if (thing.foundation == "$none$")
                {
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_8",
                        name = thing.name,
                        value = "$none$",
                        place1 = thing.foundation,
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });

                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_82",
                        name = thing.type,
                        value = "$none$",
                        place1 = thing.id + "_73",
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }
                else
                {
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_8",
                        name = thing.name,
                        value = "$none$",
                        place1 = (string)thing.value,
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                    values.Add(new Thing
                    {
                        type = "ruleConstrainsActivity",
                        id = thing.id + "_82",
                        name = thing.type,
                        value = "$none$",
                        place1 = thing.id + "_73",
                        place2 = thing.id + "_4",
                        foundation = "CoupleType",
                        value_type = "$none$"
                    });
                }

                values.Add(new Thing
                {
                    type = "Activity",
                    id = thing.id + "_4",
                    name = thing.name,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });


                MergeDictionaries(DIV2_3_optional, new Dictionary<string, List<Thing>>() { { thing.id, values } });
            }

            //State transition

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Attribute("SAPrpName") == "To"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "From"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


                    select new Thing
                    {
                        type = "BeforeAfterType",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result3.Attribute("SALinkIdentity"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "CoupleType",
                        value_type = "$none$"
                    };

            tuple_types = tuple_types.Concat(results.ToList());

            //Capability Dependency

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Attribute("SAPrpName") == "To Capability"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "From Capability"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


                    select new Thing
                    {
                        type = "BeforeAfterType",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result3.Attribute("SALinkIdentity"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "CoupleType",
                        value_type = "$none$"
                    };

            tuple_types = tuple_types.Concat(results.ToList());

            //System Milestone Dependency

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Attribute("SAPrpName") == "To Milestone"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "From Milestone"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


                    select new Thing
                    {
                        type = "BeforeAfterType",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result3.Attribute("SALinkIdentity"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "CoupleType",
                        value_type = "$none$"
                    };

            tuple_types = tuple_types.Concat(results.ToList());

            //activityPartOfProjectType

            results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == "Milestones"
                        select new Thing
                        {
                            type = "activityPartOfProjectType",
                            id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity") + "_1",
                            name = "$none$",
                            value = "$none$",
                            place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place2 = (string)result.Attribute("SALinkIdentity"),
                            foundation = "WholePartType",
                            value_type = "$none$"
                        };

            values = results.ToList();

            results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == "Project"
                        select new Thing
                        {
                            type = "activityPartOfProjectType",
                            id = (string)result.Attribute("SALinkIdentity") + (string)result.Parent.Parent.Attribute("SAObjId") + "_1",
                            name = "$none$",
                            value = "$none$",
                            place2 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place1 = (string)result.Attribute("SALinkIdentity"),
                            foundation = "WholePartType",
                            value_type = "$none$"
                        };

            values.AddRange(results.ToList());

            tuple_types = tuple_types.Concat(values.GroupBy(x => x.id).Select(grp => grp.First()));

            //activityPerformedByPerformer - Milestones

            results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == "Milestones"
                        select new Thing
                        {
                            type = "activityPerformedByPerformer",
                            id = (string)result.Parent.Parent.Attribute("SAObjId") + (string)result.Attribute("SALinkIdentity"),
                            name = "$none$",
                            value = "$none$",
                            place1 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place2 = (string)result.Attribute("SALinkIdentity"),
                            foundation = "CoupleType",
                            value_type = "$none$"
                        };

            values = results.ToList();

            results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == "In Item"
                        select new Thing
                        {
                            type = "activityPerformedByPerformer",
                            id = (string)result.Attribute("SALinkIdentity") + (string)result.Parent.Parent.Attribute("SAObjId"),
                            name = "$none$",
                            value = "$none$",
                            place2 = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place1 = (string)result.Attribute("SALinkIdentity"),
                            foundation = "CoupleType",
                            value_type = "$none$"
                        };

            values.AddRange(results.ToList());

            tuple_types = tuple_types.Concat(values.GroupBy(x => x.id).Select(grp => grp.First()));

            //Milestone Date

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty")
                    where (string)result.Attribute("SAPrpName") == "Milestone Date"

                    select new Thing
                    {
                        type = "HappensInType",
                        id = (string)result.Parent.Attribute("SAObjId") + "_t2",
                        name = "$none$",
                        value = (string)result.Attribute("SAPrpValue"),
                        place1 = (string)result.Parent.Attribute("SAObjId") + "_t1",
                        place2 = (string)result.Parent.Attribute("SAObjId"),
                        foundation = "WholePartType",
                        value_type = "$period$"
                    };

            tuple_types = tuple_types.Concat(results.ToList());

            foreach (Thing thing in results)
            {
                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "PeriodType",
                    id = thing.place2 + "_t1",
                    name = (string)thing.value,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                things = things.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "PeriodType",
                    id = thing.place2 + "_t1",
                    name = (string)thing.value,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(thing);

                period_dic.Add(thing.place2, values);
            }

            //Event Duration

            results =
                    from result in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SAObjMinorTypeName") == "BPMN Event"

                    select new Thing
                    {
                        type = "HappensInType",
                        id = (string)result.Attribute("SAObjId") + "_t2",
                        name = "$none$",
                        value = "0",
                        place1 = (string)result.Attribute("SAObjId") + "_t1",
                        place2 = (string)result.Attribute("SAObjId"),
                        foundation = "WholePartType",
                        value_type = "$duration$"
                    };

            tuple_types = tuple_types.Concat(results.ToList());

            foreach (Thing thing in results)
            {
                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Duration",
                    id = thing.place2 + "_t1",
                    name = (string)thing.value,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                things = things.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Duration",
                    id = thing.place2 + "_t1",
                    name = (string)thing.value,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(thing);

                period_dic.Add(thing.place2, values);
            }

            //Data Type

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty")
                    where (string)result.Attribute("SAPrpName") == "SQL Data Type"

                    select new Thing
                    {
                        type = "typeInstance",
                        id = (string)result.Parent.Attribute("SAObjId") + "_12",
                        name = "$none$",
                        value = (string)result.Attribute("SAPrpValue"),
                        place1 = (string)result.Parent.Attribute("SAObjId") + "_11",
                        place2 = (string)result.Parent.Attribute("SAObjId"),
                        foundation = "typeInstance",
                        value_type = "$datatype$"
                    };

            tuples = tuples.Concat(results.ToList());

            foreach (Thing thing in results)
            {
                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "DataType",
                    id = thing.place2 + "_11",
                    name = (string)thing.value,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                things = things.Concat(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "DataType",
                    id = thing.place2 + "_11",
                    name = (string)thing.value,
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                //values.Add(thing);

                datatype_optional_dic.Add(thing.place2, new List<Thing>() { thing });
                datatype_mandatory_dic.Add(thing.place2, values);
            }

            //activityPartOfCapability

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Attribute("SAPrpName") == "Activity"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "Capability"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


                    select new Thing
                    {
                        type = "activityPartOfCapability",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result3.Attribute("SALinkIdentity"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "WholePartType",
                        value_type = "$none$"
                    };

            tuple_types = tuple_types.Concat(results.ToList());

            //DIV-2 Relationships

            //results =
            //        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
            //        where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Non-specific Relation" //|| (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Relationship"
            //        where (string)result.Parent.Attribute("SAPrpName") == "From Entity"
            //        from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
            //        where (string)result3.Parent.Attribute("SAPrpName") == "To Entity"
            //        where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
            //        from result2 in root.Elements("Class").Elements("SADefinition")
            //        where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
            //        from result4 in root.Elements("Class").Elements("SADefinition")
            //        where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


            //        select new Thing
            //        {
            //            type = "OverlapType",
            //            id = (string)result.Parent.Parent.Attribute("SAObjId")+"_1",
            //            name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
            //            value = "$none$",
            //            place1 = (string)result3.Attribute("SALinkIdentity"),
            //            place2 = (string)result.Attribute("SALinkIdentity"),
            //            foundation = "CoupleType",
            //            value_type = "$none$"
            //        };

            //tuple_types = tuple_types.Concat(results.ToList());

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Super-sub Relation"
                    where (string)result.Parent.Attribute("SAPrpName") == "From Entity"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "To Entity"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result2 in root.Elements("Class").Elements("SADefinition")
                    where (string)result.Attribute("SALinkIdentity") == (string)result2.Attribute("SAObjId")
                    from result4 in root.Elements("Class").Elements("SADefinition")
                    where (string)result3.Attribute("SALinkIdentity") == (string)result4.Attribute("SAObjId")


                    select new Thing
                    {
                        type = "superSubtype",
                        id = (string)result.Parent.Parent.Attribute("SAObjId") + "_1",
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = "$none$",
                        place1 = (string)result3.Attribute("SALinkIdentity"),
                        place2 = (string)result.Attribute("SALinkIdentity"),
                        foundation = "superSubtype",
                        value_type = "$none$"
                    };

            tuple_types = tuple_types.Concat(results.ToList());

            //things_dic

            things_dic = things.ToDictionary(x => x.id, x => x);

            //System Exchange (DM2rx)

            results =
                    from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "System Exchange (DM2rx)"
                    where (string)result.Parent.Attribute("SAPrpName") == "Source"
                    from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result3.Parent.Attribute("SAPrpName") == "Target"
                    where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")
                    from result5 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                    where (string)result5.Parent.Attribute("SAPrpName") == "System Resource Flow"
                    where (string)result5.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")

                    select new Thing
                    {
                        type = "System Exchange (DM2rx)",
                        id = (string)result.Parent.Parent.Attribute("SAObjId"),
                        name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        value = (string)result5.Attribute("SALinkIdentity"),
                        place1 = (string)result.Attribute("SALinkIdentity"),
                        place2 = (string)result3.Attribute("SALinkIdentity"),
                        foundation = "$none$",
                        value_type = "$flow$"
                    };

            values_dic = results.ToDictionary(x => x.id, x => x);

            results =
                   from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                   where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "System Exchange (DM2rx)"
                   where (string)result.Parent.Attribute("SAPrpName") == "Source"
                   from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                   where (string)result3.Parent.Attribute("SAPrpName") == "Target"
                   where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Parent.Parent.Attribute("SAObjId")

                   select new Thing
                   {
                       type = "System Exchange (DM2rx)",
                       id = (string)result.Parent.Parent.Attribute("SAObjId"),
                       name = ((string)result.Parent.Parent.Attribute("SAObjName")).Replace("&", " And "),
                       value = "$none$",
                       place1 = (string)result.Attribute("SALinkIdentity"),
                       place2 = (string)result3.Attribute("SALinkIdentity"),
                       foundation = "$none$",
                       value_type = "$none$"
                   };

            foreach (Thing thing in results)
            {
                if (!values_dic.TryGetValue(thing.id, out value))
                    errors_list.Add("Definition error," + thing.id + "," + thing.name + "," + thing.type + ",Missing Mandatory Element: System Resource Flow\r\n");
            }

            //values_dic = tuple_types.Where(x => x.type == "activityPerformedByPerformer").ToDictionary(x => x.id, x => x);

            //foreach (Thing thing in results)
            //{
            //    values = new List<Thing>();
            //    values2 = new List<Thing>();
            //    mandatory_list  = new List<Thing>();

            //    values_dic.TryGetValue(thing.place1, out value);

            //    values.Add(new Thing
            //    {
            //        type = "activityProducesResource",
            //        id = thing.place1 + "_1",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = thing.id,
            //        place2 = value.place2,
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });

            //    mandatory_list.Add(value);
            //    mandatory_list.Add(things_dic[value.place1]);
            //    mandatory_list.Add(things_dic[value.place2]);

            //    values2.Add(new Thing
            //    {
            //        type = "Data",
            //        id = thing.id,
            //        name = "Resource",
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });

            //    things_dic.Add(thing.id, new Thing
            //    {
            //        type = "Data",
            //        id = thing.id,
            //        name = "Resource",
            //        value = "$none$",
            //        place1 = "$none$",
            //        place2 = "$none$",
            //        foundation = "IndividualType",
            //        value_type = "$none$"
            //    });


            //    values_dic.TryGetValue(thing.place2, out value);

            //    values.Add(new Thing
            //    {
            //        type = "activityConsumesResource",
            //        id = thing.id + "_2",
            //        name = thing.name,
            //        value = "$none$",
            //        place1 = value.place2,
            //        place2 = thing.id,
            //        foundation = "CoupleType",
            //        value_type = "$none$"
            //    });


            //    mandatory_list.Add(value);
            //    mandatory_list.Add(things_dic[value.place1]);
            //    mandatory_list.Add(things_dic[value.place2]);
            //    mandatory_list.AddRange(values);
            //    mandatory_list.AddRange(values2);

            //    needline_mandatory_views.Add(thing.id, mandatory_list);
            //}

            //things = things.Concat(values2);

            //tuple_types = tuple_types.Concat(values);

            //Organization Owns Projects and PV-1

            //results =
            //            from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
            //            where (string)result.Parent.Attribute("SAPrpName") == "Organization Owns Projects"
            //            from result2 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
            //            where (string)result2.Parent.Attribute("SAPrpName") == "Milestones"
            //            where (string)result.Attribute("SALinkIdentity") == (string)result2.Parent.Parent.Attribute("SAObjId")

            //            select new Thing
            //            {
            //                type = "activityPerformedByPerformer",
            //                id = (string)result2.Attribute("SALinkIdentity") + (string)result.Parent.Parent.Attribute("SAObjId"),
            //                name = ((string)result2.Attribute("SALinkName")).Replace("&quot", "").Replace("\"",""),
            //                value = new Tuple<string, string>((string)result.Parent.Parent.Parent.Element("SADiagram").Attribute("SAObjId"), (string)result2.Parent.Parent.Attribute("SAObjId")),
            //                place2 = (string)result.Parent.Parent.Attribute("SAObjId"),
            //                place1 = (string)result2.Attribute("SALinkIdentity"),
            //                foundation = "CoupleType",
            //                value_type = "$view and project$"
            //            };

            //    IEnumerable<Thing> tuple_types_temp = results.ToList();

            results =
                        from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                        where (string)result.Parent.Attribute("SAPrpName") == "Project Owned By Organization"
                        from result2 in result.Parent.Parent.Elements("SAProperty").Elements("SALink")
                        where (string)result2.Parent.Attribute("SAPrpName") == "Milestones"

                        select new Thing
                        {
                            type = "activityPerformedByPerformer",
                            id = (string)result2.Attribute("SALinkIdentity") + (string)result.Attribute("SALinkIdentity"),
                            name = ((string)result2.Attribute("SALinkName")).Replace("&quot", "").Replace("\"", ""),
                            //value = new Tuple<string, string>((string)result.Parent.Parent.Parent.Element("SADiagram").Attribute("SAObjId"), (string)result.Parent.Parent.Attribute("SAObjId")),
                            value = (string)result.Parent.Parent.Attribute("SAObjId"),
                            place2 = (string)result.Attribute("SALinkIdentity"),
                            place1 = (string)result2.Attribute("SALinkIdentity"),
                            foundation = "CoupleType",
                            value_type = "$view and project$"
                        };

            if (results.Count() > 0)
            {
                IEnumerable<Thing> tuple_types_temp = results.ToList();

                //tuple_types_temp = tuple_types_temp.Concat(results.ToList());

                //tuple_types_temp = tuple_types_temp.GroupBy(x => x.id).Select(grp => grp.First());

                tuple_types = tuple_types.Concat(tuple_types_temp);

                results2 = tuple_types_temp;

                foreach (Thing thing in tuple_types_temp)
                {
                    if (things_dic.TryGetValue(thing.place1, out value))
                    {
                        results2 = results2.Concat(new[] { value });
                    }
                    else
                    {
                        values = new List<Thing>();

                        values.Add(new Thing
                        {
                            type = "Activity",
                            id = thing.place1,
                            name = thing.name,
                            value = thing.value,
                            place2 = "$none$",
                            place1 = "$none$",
                            foundation = "IndividualType",
                            value_type = "$view and project$"

                        });

                        things = things.Concat(values);

                        things_dic.Add(thing.place1, values.First());

                        results2 = results2.Concat(values);

                        values = new List<Thing>();

                        values.Add(new Thing
                        {
                            type = "activityPartOfProjectType",
                            id = (string)thing.value + thing.place1,
                            name = "$none$",
                            value = thing.value,
                            place1 = (string)thing.value,
                            place2 = thing.place1,
                            foundation = "IndividualType",
                            value_type = "$view and project$"

                        });

                        tuple_types = tuple_types.Concat(values);

                        results2 = results2.Concat(values);
                    }
                }

                results =
                           from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol")
                           where (string)result.Parent.Attribute("SAObjMinorTypeName") == "PV-01 Project Portfolio Relationships (DM2)" || (string)result.Parent.Attribute("SAObjMinorTypeName") == "PV-01 Project Portfolio Relationships At Time (DM2)"
                           where (string)result.Attribute("SAObjMinorTypeName") == "Project (DM2)"

                           select new Thing
                           {
                               type = "temp",
                               id = (string)result.Parent.Attribute("SAObjId") + "_" + (string)result.Attribute("SASymIdDef"),
                               place1 = (string)result.Parent.Attribute("SAObjId"),
                               place2 = (string)result.Attribute("SASymIdDef")
                           };

                results_dic = results2.GroupBy(y => (string)y.value).ToDictionary(z => z.Key, z => z.ToList());

                sorted_results = results.GroupBy(x => x.place1).Select(group => group.Distinct().ToList()).ToList();

                foreach (List<Thing> view in sorted_results)
                {
                    values2 = new List<Thing>();

                    foreach (Thing thing in view)
                    {
                        values = new List<Thing>();

                        if (results_dic.TryGetValue(thing.place2, out values))
                        {
                            values2.AddRange(values);
                        }
                    }
                    PV1_mandatory_views.Add(view.First().place1, values2);
                }
            }
            //PV1_mandatory_views = tuple_types_temp_new.GroupBy(y => ((Tuple<string, string>)y.value).Item1).ToDictionary(z => ((Tuple<string, string>)z.First().value).Item1, z => z.ToList());

            //BPMN Lookup

            results =
                          from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                          where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Call Activity"
                          //|| (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Sequence Flow"

                          select new Thing
                          {
                              type = "temp",
                              id = (string)result.Attribute("SALinkIdentity"),
                              name = (string)result.Parent.Parent.Attribute("SAObjName"),
                              foundation = (string)result.Parent.Parent.Attribute("SAObjId"),
                          };

            bpmn_lookup = results.ToDictionary(x => x.foundation, x => new List<Thing>() { x });

            results =
                          from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                          where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Participant"
                          //|| (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Sequence Flow"

                          select new Thing
                          {
                              type = "temp",
                              id = (string)result.Attribute("SALinkIdentity"),
                              name = (string)result.Parent.Parent.Attribute("SAObjName"),
                              foundation = (string)result.Parent.Parent.Attribute("SAObjId"),
                          };

            MergeDictionaries(bpmn_lookup, results.ToDictionary(x => x.foundation, x => new List<Thing>() { x }));

            //values = new List<Thing>();
            foreach (Thing thing in results)
            {
                things_dic.Remove(thing.foundation);
                //var itemToRemove = things.SingleOrDefault(r => r.id == thing.foundation);
                //if (itemToRemove != null)
                //    values.Add(itemToRemove);
            }

            //things = things.Except(values);

            results =
                         from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                         where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "BPMN Process"
                         //|| (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Sequence Flow"

                         select new Thing
                         {
                             type = "temp",
                             id = (string)result.Attribute("SALinkIdentity"),
                             name = (string)result.Parent.Parent.Attribute("SAObjName"),
                             foundation = (string)result.Parent.Parent.Attribute("SAObjId"),
                         };

            MergeDictionaries(bpmn_lookup, results.ToDictionary(x => x.foundation, x => new List<Thing>() { x }));

            //values = new List<Thing>();
            foreach (Thing thing in results)
            {
                things_dic.Remove(thing.foundation);
                //var itemToRemove = things.SingleOrDefault(r => r.id == thing.foundation);
                //if (itemToRemove != null)
                //    values.Add(itemToRemove);
            }

            //things = things.Except(values);

            //results =
            //              from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol")
            //              where (string)result.Attribute("SAObjMinorTypeName") == "Call Activity"
            //              //|| (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Sequence Flow"

            //              select new Thing
            //              {
            //                  type = "temp",
            //                  id = (string)result.Parent.Attribute("SAObjId"),
            //                  foundation = (string)result.Attribute("SASymIdDef")
            //              };

            //values_dic = new Dictionary<string, Thing>();

            //foreach (Thing thing in results)
            //{
            //    if (bpmn_lookup.TryGetValue(thing.foundation, out value))
            //        values_dic.Add(thing.id + value.id, thing);
            //}

            results =
                          from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                          where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Sequence Flow"
                          from result2 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                          where (string)result2.Parent.Attribute("SAPrpName") == "consumingActivity"
                          where (string)result2.Parent.Parent.Attribute("SAObjId") == (string)result.Attribute("SALinkIdentity")
                          from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                          where (string)result3.Parent.Attribute("SAPrpName") == "producingActivity"
                          where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Attribute("SALinkIdentity")
                          where result.Parent.Parent.Parent.Elements("SADiagram") != null

                          select new Thing
                          {
                              type = "temp",
                              name = (string)result.Parent.Parent.Attribute("SAObjName"),
                              id = (string)result.Attribute("SALinkIdentity"),
                              place1 = (string)result2.Attribute("SALinkIdentity"),
                              place2 = (string)result3.Attribute("SALinkIdentity"),
                              foundation = (string)result.Parent.Parent.Attribute("SAObjId"),
                              value = (string)result.Parent.Parent.Parent.Element("SADiagram").Attribute("SAObjId"),
                              value_type = "$view_id$"
                          };


            foreach (Thing thing in results)
            {
                //if(values_dic.TryGetValue(thing.value + thing.place1,out value)
                //    && values_dic.TryGetValue(thing.value + thing.place2,out value2))
                //    bpmn_lookup.Add(thing.foundation,thing); 
                //else
                //    errors_list.Add("Diagram error," + thing.value + "," + thing.name + ",OV-6c, Related ARO error - Sequence Flow Ignored: " + thing.foundation + "\r\n");

                value = new Thing
                    {
                        type = "BeforeAfterType",
                        id = thing.id + "_30",
                        name = thing.name,
                        value = "BeforeAfterType",
                        place1 = thing.place2,
                        place2 = thing.place1,
                        foundation = "CoupleType",
                        value_type = "$none$"
                    };

                tuple_types = tuple_types.Concat(new List<Thing>() { value });

                values = new List<Thing>();

                values.Add(thing);
                values.Add(value);
                bpmn_lookup.Add(thing.foundation, values);

            }

            results =
                         from result in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                         where (string)result.Parent.Parent.Attribute("SAObjMinorTypeName") == "Message Flow"
                         from result2 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                         where (string)result2.Parent.Attribute("SAPrpName") == "consumingActivity"
                         where (string)result2.Parent.Parent.Attribute("SAObjId") == (string)result.Attribute("SALinkIdentity")
                         from result3 in root.Elements("Class").Elements("SADefinition").Elements("SAProperty").Elements("SALink")
                         where (string)result3.Parent.Attribute("SAPrpName") == "producingActivity"
                         where (string)result3.Parent.Parent.Attribute("SAObjId") == (string)result.Attribute("SALinkIdentity")
                         where result.Parent.Parent.Parent.Elements("SADiagram") != null

                         select new Thing
                         {
                             type = "temp",
                             name = (string)result.Parent.Parent.Attribute("SAObjName"),
                             id = (string)result.Attribute("SALinkIdentity"),
                             place1 = (string)result2.Attribute("SALinkIdentity"),
                             place2 = (string)result3.Attribute("SALinkIdentity"),
                             foundation = (string)result.Parent.Parent.Attribute("SAObjId"),
                             value = (string)result.Parent.Parent.Parent.Element("SADiagram").Attribute("SAObjId"),
                             value_type = "$view_id$"
                         };

            foreach (Thing thing in results)
            {
                //if (values_dic.TryGetValue(thing.value + thing.place1, out value)
                //    && values_dic.TryGetValue(thing.value + thing.place2, out value2))
                bpmn_lookup.Add(thing.foundation, new List<Thing>() { thing });
                //else
                //    errors_list.Add("Diagram error," + thing.value + "," + thing.name + ",OV-6c, Related ARO error - Message Flow Ignored: " + thing.foundation + "\r\n");
            }

            foreach (List<Thing> list in bpmn_lookup.Values.ToList())
            {
                Thing thing = list.First();
                things_dic.Add(thing.foundation,

                    new Thing
                         {
                             type = "Information",
                             name = "BPMN Name",
                             id = thing.foundation,
                             place1 = "$none$",
                             place2 = "$none$",
                             foundation = "IndividualType",
                             value = (string)thing.name,
                             value_type = "examplar"
                         }

                );

                tuple_types = tuple_types.Concat(new List<Thing>(){
                    new Thing
                            {
                                type = "describedBy",
                                id = thing.foundation + "_i2",
                                foundation = "namedBy",
                                place1 = thing.id,
                                place2 = thing.foundation,
                                name = "$none$",
                                value = "$none$",
                                value_type = "$none$"
                            }
                    }
                );
            }

            //ToLists
            things = things.GroupBy(x => x.id).Select(grp => grp.First());
            tuples = tuples.GroupBy(x => x.id).Select(grp => grp.First());
            tuple_types = tuple_types.GroupBy(x => x.id).Select(grp => grp.First());
            values3 = tuples.ToList();
            values4 = tuple_types.ToList();
            values5 = new List<Thing>();
            values6 = new List<Thing>();
            values7 = new List<Thing>();
            things = null;
            tuples = null;
            tuple_types = null;

            //Derived Views

            //AV-2

            //sorted_results = new List<List<Thing>>();
            //optional_list = new List<Thing>();
            //values = new List<Thing>();

            //foreach (Thing thing in things_dic.Select(kvp => kvp.Value).ToList().OrderBy(x => x.type).ToList())
            //{
            //    optional_list.Add(new Thing { id = thing.id, type = thing.type, value = "$none$", value_type = "$none$" });
            //    values.Add(new Thing { id = "_1", type = "AV-2", place2 = thing.id, value = thing.type, place1 = "_1" });
            //}

            //sorted_results.Add(values);

            //sorted_results_new = new List<List<Thing>>();
            //Add_Tuples(ref sorted_results, ref sorted_results_new, values3, ref errors_list);
            //Add_Tuples(ref sorted_results, ref sorted_results_new, values4, ref errors_list);
            //sorted_results = sorted_results_new;

            //foreach (Thing thing in sorted_results.First())
            //{
            //    if ((string)thing.value == "superSubtype" || (string)thing.value == "WholePartType")
            //        optional_list.Add(new Thing { id = thing.place2, type = (string)thing.value, value = "$none$", value_type = "$none$" });
            //}

            //views.Add(new View { type = "AV-2", id = "_1", name = "NEAR AV-2", optional = optional_list, mandatory = new List<Thing>() });

            ////OV-3

            //mandatory_list = new List<Thing>();
            //values = new List<Thing>();
            //optional_list = new List<Thing>();
            //sorted_results = new List<List<Thing>>();

            //values_dic2 = things_dic.Where(x => x.Value.type == "Resource").ToDictionary(p => p.Key, p => p.Value);

            //results = values4.Where(x => x.type == "activityConsumesResource").Where(x => values_dic2.ContainsKey(x.place1));
            //values_dic = values4.Where(x => x.type == "activityProducesResource").GroupBy(x => x.place2).Where(x => x.Count() == 1).Select(grp => grp.First()).ToDictionary(x => x.place2, x=>x);

            //foreach (Thing rela in results)
            //{
            //    if(values_dic.TryGetValue(rela.place1, out value))
            //    {
            //        values.Add(rela);
            //        values.Add(value);
            //    }

            //}

            //count = 0;
            //count2 = values.Count();

            ////var duplicateKeys = app2.GroupBy(x => x.place2)
            ////            .Where(group => group.Count() > 1)
            ////            .Select(group => group.Key);

            ////List<string> test = duplicateKeys.ToList();

            //values_dic2 = values4.Where(x => x.type == "activityPerformedByPerformer").Where(x => Allowed_Element("OV-3", x.place1, ref things_dic)).GroupBy(x => x.place2).Select(grp => grp.First()).ToDictionary(x => x.place2, x => x);

            //while (count < count2)
            //{
            //    add = false;

            //    foreach (Thing thing in values)
            //    {
            //        if (values_dic2.TryGetValue(values[count].place2, out value))
            //            if (values_dic2.TryGetValue(values[count + 1].place1, out value2))
            //            {
            //                add = true;
            //                values.Add(value);
            //                values.Add(value2);
            //                break;
            //            }
            //    }


            //    if (add == true)
            //    {
            //        count = count + 2;
            //    }
            //    else
            //    {
            //        values.RemoveAt(count);
            //        values.RemoveAt(count);
            //        count2 = count2 - 2;
            //    }
            //}

            //sorted_results.Add(Add_Places(things_dic, values));

            //foreach (Thing thing in sorted_results.First())
            //{
            //    temp = Find_Mandatory_Optional(thing.type, "OV-3", "OV-3", "_2", ref errors_list);
            //    if (temp == "Mandatory")
            //        mandatory_list.Add(new Thing { id = thing.id, type = thing.type, value = "$none$", value_type = "$none$" });
            //    if (temp == "Optional")
            //        optional_list.Add(new Thing { id = thing.id, type = thing.type, value = "$none$", value_type = "$none$" });
            //}

            //if (sorted_results.First().Count() > 0)
            //    views.Add(new View { type = "OV-3", id = "_2", name = "NEAR OV-3", optional = optional_list, mandatory = mandatory_list });

            ////SV-6

            //mandatory_list = new List<Thing>();
            //values = new List<Thing>();
            //optional_list = new List<Thing>();
            //sorted_results = new List<List<Thing>>();

            //values_dic2 = things_dic.Where(x => x.Value.type == "Data").ToDictionary(p => p.Key, p => p.Value);

            //results = values4.Where(x => x.type == "activityConsumesResource").Where(x => values_dic2.ContainsKey(x.place1));
            //values_dic = values4.Where(x => x.type == "activityProducesResource").GroupBy(x => x.place2).Where(x => x.Count() == 1).Select(grp => grp.First()).ToDictionary(x => x.place2, x => x);

            //foreach (Thing rela in results)
            //{
            //    if (values_dic.TryGetValue(rela.place1, out value))
            //    {
            //        values.Add(rela);
            //        values.Add(value);
            //    }

            //}

            //count = 0;
            //count2 = values.Count();

            ////var duplicateKeys = app2.GroupBy(x => x.place2)
            ////            .Where(group => group.Count() > 1)
            ////            .Select(group => group.Key);

            ////List<string> test = duplicateKeys.ToList();

            //values_dic2 = values4.Where(x => x.type == "activityPerformedByPerformer").Where(x => Allowed_Element("SV-6", x.place1, ref things_dic)).GroupBy(x => x.place2).Select(grp => grp.First()).ToDictionary(x => x.place2, x => x);

            //while (count < count2)
            //{
            //    add = false;

            //    foreach (Thing thing in values)
            //    {
            //        if (values_dic2.TryGetValue(values[count].place2, out value))
            //            if (values_dic2.TryGetValue(values[count + 1].place1, out value2))
            //            {
            //                add = true;
            //                values.Add(value);
            //                values.Add(value2);
            //                break;
            //            }
            //    }


            //    if (add == true)
            //    {
            //        count = count + 2;
            //    }
            //    else
            //    {
            //        values.RemoveAt(count);
            //        values.RemoveAt(count);
            //        count2 = count2 - 2;
            //    }
            //}

            //sorted_results.Add(Add_Places(things_dic, values));

            //foreach (Thing thing in sorted_results.First())
            //{
            //    temp = Find_Mandatory_Optional(thing.type, "SV-6", "SV-6", "_3", ref errors_list);
            //    if (temp == "Mandatory")
            //        mandatory_list.Add(new Thing { id = thing.id, type = thing.type, value = "$none$", value_type = "$none$" });
            //    if (temp == "Optional")
            //        optional_list.Add(new Thing { id = thing.id, type = thing.type, value = "$none$", value_type = "$none$" });
            //}

            //if (sorted_results.First().Count() > 0)
            //    views.Add(new View { type = "SV-6", id = "_3", name = "NEAR SV-6", optional = optional_list, mandatory = mandatory_list });

            ////SvcV-6

            //mandatory_list = new List<Thing>();
            //values = new List<Thing>();
            //optional_list = new List<Thing>();
            //sorted_results = new List<List<Thing>>();

            //values_dic2 = things_dic.Where(x => x.Value.type == "Data").ToDictionary(p => p.Key, p => p.Value);

            //results = values4.Where(x => x.type == "activityConsumesResource").Where(x => values_dic2.ContainsKey(x.place1));
            //values_dic = values4.Where(x => x.type == "activityProducesResource").GroupBy(x => x.place2).Where(x => x.Count() == 1).Select(grp => grp.First()).ToDictionary(x => x.place2, x => x);

            //foreach (Thing rela in results)
            //{
            //    if (values_dic.TryGetValue(rela.place1, out value))
            //    {
            //        values.Add(rela);
            //        values.Add(value);
            //    }

            //}

            //count = 0;
            //count2 = values.Count();

            ////var duplicateKeys = app2.GroupBy(x => x.place2)
            ////            .Where(group => group.Count() > 1)
            ////            .Select(group => group.Key);

            ////List<string> test = duplicateKeys.ToList();

            //values_dic2 = values4.Where(x => x.type == "activityPerformedByPerformer").Where(x => Allowed_Element("SvcV-6", x.place1, ref things_dic)).GroupBy(x => x.place2).Select(grp => grp.First()).ToDictionary(x => x.place2, x => x);

            //while (count < count2)
            //{
            //    add = false;

            //    foreach (Thing thing in values)
            //    {
            //        if (values_dic2.TryGetValue(values[count].place2, out value))
            //            if (values_dic2.TryGetValue(values[count + 1].place1, out value2))
            //            {
            //                add = true;
            //                values.Add(value);
            //                values.Add(value2);
            //                break;
            //            }
            //    }


            //    if (add == true)
            //    {
            //        count = count + 2;
            //    }
            //    else
            //    {
            //        values.RemoveAt(count);
            //        values.RemoveAt(count);
            //        count2 = count2 - 2;
            //    }
            //}

            //sorted_results.Add(Add_Places(things_dic, values));

            //foreach (Thing thing in sorted_results.First())
            //{

            //    temp = Find_Mandatory_Optional(thing.type, "SvcV-6", "SvcV-6", "_4", ref errors_list);
            //    if (temp == "Mandatory")
            //        mandatory_list.Add(new Thing { id = thing.id, type = thing.type, value = "$none$", value_type = "$none$" });
            //    if (temp == "Optional")
            //        optional_list.Add(new Thing { id = thing.id, type = thing.type, value = "$none$", value_type = "$none$" });

            //    if ((string)thing.type == "Service")
            //    {
            //        values = new List<Thing>();

            //        values.Add(new Thing
            //        {
            //            type = "ServiceDescription",
            //            id = thing.place2 + "_2",
            //            name = thing.place2 + "_Description",
            //            value = "$none$",
            //            place1 = "$none$",
            //            place2 = "$none$",
            //            foundation = "Individual",
            //            value_type = "$none$"
            //        });

            //        values.Add(new Thing
            //        {
            //            type = "serviceDescribedBy",
            //            id = thing.place2 + "_1",
            //            name = "$none$",
            //            value = "$none$",
            //            place1 = thing.id,
            //            place2 = thing.id + "_2",
            //            foundation = "namedBy",
            //            value_type = "$none$"
            //        });

            //        mandatory_list.AddRange(values);
            //    }
            //}

            //if (sorted_results.First().Count() > 0)
            //    views.Add(new View { type = "SvcV-6", id = "_4", name = "NEAR SvcV-6", optional = optional_list, mandatory = mandatory_list });

            //DIV-3 Parts

            results_dic = values4.Where(x => x.type == "WholePartType").GroupBy(x => x.place1).ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

            //Diagramming Information

            locations =
                    from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol")
                    where (string)result.Attribute("SASymIdDef") != null
                        || (string)result.Attribute("SAObjMinorTypeName") == "Picture" || (string)result.Attribute("SAObjMinorTypeName") == "Doc Block"
                    select new Location
                    {
                        id = ((string)result.Attribute("SAObjMinorTypeName") == "Picture" || (string)result.Attribute("SAObjMinorTypeName") == "Doc Block") ? (string)result.Parent.Attribute("SAObjId") + (string)result.Attribute("SAObjId") : (string)result.Parent.Attribute("SAObjId") + (string)result.Attribute("SAObjId"),
                        top_left_x = (string)result.Attribute("SASymLocX"),
                        top_left_y = (string)result.Attribute("SASymLocY"),
                        bottom_right_x = ((int)result.Attribute("SASymLocX") + (int)result.Attribute("SASymSizeX")).ToString(),
                        bottom_right_y = ((int)result.Attribute("SASymLocY") - (int)result.Attribute("SASymSizeY")).ToString(),
                        element_id = ((string)result.Attribute("SAObjMinorTypeName") == "Picture" || (string)result.Attribute("SAObjMinorTypeName") == "Doc Block") ? (string)result.Attribute("SAObjId") : (string)result.Attribute("SASymIdDef")
                    };

            foreach (Location location in locations)
            {
                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "Information",
                    id = location.id + "_12",
                    name = "Diagramming Information",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "Point",
                    id = location.id + "_16",
                    name = "Top Left Location",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "PointType",
                    id = location.id + "_14",
                    name = "Top Left LocationType",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "Point",
                    id = location.id + "_26",
                    name = "Bottome Right Location",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "PointType",
                    id = location.id + "_24",
                    name = "Bottome Right LocationType",
                    value = "$none$",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "SpatialMeasure",
                    id = location.id + "_18",
                    name = "Top Left X Location",
                    value = location.top_left_x,
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "numericValue",
                });

                values.Add(new Thing
                {
                    type = "SpatialMeasure",
                    id = location.id + "_20",
                    name = "Top Left Y Location",
                    value = location.top_left_y,
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "numericValue"
                });

                values.Add(new Thing
                {
                    type = "SpatialMeasure",
                    id = location.id + "_22",
                    name = "Top Left Z Location",
                    value = "0",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "numericValue"
                });

                values.Add(new Thing
                {
                    type = "SpatialMeasure",
                    id = location.id + "_28",
                    name = "Bottom Right X Location",
                    value = location.bottom_right_x,
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "numericValue"
                });

                values.Add(new Thing
                {
                    type = "SpatialMeasure",
                    id = location.id + "_30",
                    name = "Bottom Right Y Location",
                    value = location.bottom_right_y,
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "numericValue"
                });

                values.Add(new Thing
                {
                    type = "SpatialMeasure",
                    id = location.id + "_32",
                    name = "Bottom Right Z Location",
                    value = "0",
                    place1 = "$none$",
                    place2 = "$none$",
                    foundation = "IndividualType",
                    value_type = "numericValue"
                });

                values5.AddRange(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "describedBy",
                    id = location.id + "_11",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.element_id,
                    place2 = location.id + "_12",
                    foundation = "namedBy",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "typeInstance",
                    id = location.id + "_15",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_14",
                    place2 = location.id + "_16",
                    foundation = "typeInstance",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "typeInstance",
                    id = location.id + "_25",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_24",
                    place2 = location.id + "_26",
                    foundation = "typeInstance",
                    value_type = "$none$"
                });


                values.Add(new Thing
                {
                    type = "measureOfIndividualPoint",
                    id = location.id + "_17",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_18",
                    place2 = location.id + "_16",
                    foundation = "typeInstance",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "measureOfIndividualPoint",
                    id = location.id + "_19",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_20",
                    place2 = location.id + "_16",
                    foundation = "typeInstance",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "measureOfIndividualPoint",
                    id = location.id + "_21",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_22",
                    place2 = location.id + "_16",
                    foundation = "typeInstance",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "measureOfIndividualPoint",
                    id = location.id + "_27",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_28",
                    place2 = location.id + "_26",
                    foundation = "typeInstance",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "measureOfIndividualPoint",
                    id = location.id + "_29",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_30",
                    place2 = location.id + "_26",
                    foundation = "typeInstance",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "measureOfIndividualPoint",
                    id = location.id + "_31",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_32",
                    place2 = location.id + "_26",
                    foundation = "typeInstance",
                    value_type = "$none$"
                });

                values7.AddRange(values);

                values = new List<Thing>();

                values.Add(new Thing
                {
                    type = "resourceInLocationType",
                    id = location.id + "_13",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_12",
                    place2 = location.id + "_14",
                    foundation = "CoupleType",
                    value_type = "$none$"
                });

                values.Add(new Thing
                {
                    type = "resourceInLocationType",
                    id = location.id + "_23",
                    name = "$none$",
                    value = "$none$",
                    place1 = location.id + "_12",
                    place2 = location.id + "_24",
                    foundation = "CoupleType",
                    value_type = "$none$"
                });


                values6.AddRange(values);
            }

            locations = null;
            values = null;
            values2 = null;
            values_dic = null;
            values_dic2 = null;
            results2 = null;

            //View Compilation

            values_dic2 = values4.Where(x => x.type == "activityPerformedByPerformer").ToDictionary(x => x.id, x => x);

            foreach (string[] current_lookup in View_Lookup)
            {
                sorted_results = new List<List<Thing>>();

                results =
                    from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol")
                    where (string)result.Parent.Attribute("SAObjMinorTypeName") == current_lookup[1]
                    where (string)result.Attribute("SASymIdDef") != null
                        || ((string)result.Attribute("SAObjMinorTypeName") == "Picture"
                        || (string)result.Attribute("SAObjMinorTypeName") == "Doc Block")
                    select new Thing
                    {
                        type = current_lookup[0],
                        id = (string)result.Parent.Attribute("SAObjId") + (string)result.Attribute("SASymIdDef"),
                        name = ((string)result.Parent.Attribute("SAObjName")).Replace("&", " And "),
                        place1 = (string)result.Parent.Attribute("SAObjId"),
                        place2 = (string)result.Attribute("SASymIdDef"),
                        value = (string)result.Attribute("SASymIdDef"),
                        //value = Find_Def_DM2_Type((string)result.Attribute("SASymIdDef"),ref values5),
                        foundation = (string)result.Parent.Attribute("SAObjMinorTypeNum"),
                        value_type = "$element_type$"
                    };
                view_holder.Add(results.ToList());
            }

            root = null;

            foreach (List<Thing> view_elements in view_holder)
            {
                //foreach (Thing thing in values)
                int max = view_elements.Count;
                for (int i = 0; i < max; i++)
                {
                    Thing thing = view_elements[i];
                    //thing.value = (string) Find_Def_DM2_Type((string)thing.value, values5.ToList());
                    if (thing.place2 != null)
                    {
                        if (thing.foundation == "142")
                        {
                            if (bpmn_lookup.TryGetValue(thing.place2, out values))
                            {
                                thing.place2 = values.First().id;
                                if (values.Count() > 1)
                                {
                                    view_elements.Add(new Thing
                                    {
                                        type = thing.type,
                                        id = thing.place1 + values[1].id,
                                        name = thing.name,
                                        value = values[1].value,
                                        place1 = thing.place1,
                                        place2 = values[1].id,
                                        foundation = thing.foundation,
                                        value_type = thing.value_type
                                    });
                                    max++;
                                }
                            }
                        }

                        if (things_dic.TryGetValue(thing.place2, out value))
                            thing.value = (string)value.type;

                        if (thing.type == "DIV-3" || thing.type == "DIV-2")
                        {
                            values2 = new List<Thing>();

                            if (results_dic.TryGetValue(thing.place2, out values2))
                            {
                                foreach (Thing item in values2)
                                {
                                    view_elements.Add(new Thing
                                    {
                                        type = thing.type,
                                        id = thing.id,
                                        name = thing.name,
                                        value = thing.value,
                                        place1 = thing.place1,
                                        place2 = item.place2,
                                        foundation = thing.foundation,
                                        value_type = thing.value_type
                                    });
                                    max++;
                                }
                            }
                        }
                    }
                }

                sorted_results = view_elements.GroupBy(x => x.place1).Select(group => group.Distinct().ToList()).ToList();

                sorted_results_new = new List<List<Thing>>();
                Add_Tuples(ref sorted_results, ref sorted_results_new, values3, ref errors_list);
                Add_Tuples(ref sorted_results, ref sorted_results_new, values4, ref errors_list);
                sorted_results = sorted_results_new;

                foreach (List<Thing> view in sorted_results)
                {

                    if (view.Count() == 0)
                        continue;

                    mandatory_list = new List<Thing>();
                    optional_list = new List<Thing>();

                    if (view.First().type == "CV-1")
                    {
                        if (CV1_mandatory_views.TryGetValue(view.First().place1, out values))
                            mandatory_list.AddRange(values);
                    }

                    if (view.First().type == "PV-1")
                    {
                        values = new List<Thing>();
                        if (PV1_mandatory_views.TryGetValue(view.First().place1, out values))
                            mandatory_list.AddRange(values);
                    }

                    foreach (Thing thing in view)
                    {

                        if (thing.place2 != null)
                        {

                            if (values_dic2.TryGetValue(thing.place2, out value))
                            {
                                values = new List<Thing>();
                                values.Add(value);
                                if (Allowed_Needline(thing.type, values, ref things_dic) == false)
                                {
                                    continue;
                                }
                            }

                            if (((string)thing.value).Substring(0, 1) != "_")
                            {
                                temp = Find_Mandatory_Optional((string)thing.value, view.First().name, thing.type, thing.place1, ref errors_list);
                                if (temp == "Mandatory")
                                {
                                    mandatory_list.Add(new Thing { id = thing.place2, type = (string)thing.value, value = "$none$", value_type = "$none$" });
                                }
                                if (temp == "Optional")
                                {
                                    optional_list.Add(new Thing { id = thing.place2, type = (string)thing.value, value = "$none$", value_type = "$none$" });
                                }
                            }

                            values = new List<Thing>();
                            if (needline_mandatory_views.TryGetValue(thing.place2, out values))
                            {
                                if (Allowed_Needline(thing.type, values, ref things_dic) == true)
                                {
                                    mandatory_list.AddRange(values);
                                    //if (!view.First().type.Contains("SV-4") && !view.First().type.Contains("SvcV-4") && !view.First().type.Contains("SV-10b"))
                                    if (needline_optional_views.TryGetValue(thing.place2, out values2))
                                    {
                                        if (thing.type.Contains("SvcV-4") || thing.type.Contains("SV-4"))
                                            mandatory_list.AddRange(values2);
                                        else
                                            optional_list.AddRange(values2);
                                    }
                                    //optional_list.AddRange(needline_optional_views[thing.place2]);
                                }
                            }

                            values = new List<Thing>();
                            if (description_views.TryGetValue(thing.place2, out values))
                                optional_list.AddRange(values);

                            values = new List<Thing>();
                            if (period_dic.TryGetValue(thing.place2, out values))
                                optional_list.AddRange(values);

                            if (thing.type.Contains("DIV-3"))
                            {
                                values = new List<Thing>();
                                if (datatype_mandatory_dic.TryGetValue(thing.place2, out values))
                                    mandatory_list.AddRange(values);

                                values = new List<Thing>();
                                if (datatype_optional_dic.TryGetValue(thing.place2, out values))
                                    optional_list.AddRange(values);
                            }

                            if (thing.type.Contains("SvcV"))
                            {
                                if ((string)thing.value == "Service")
                                {
                                    values = new List<Thing>();

                                    values.Add(new Thing
                                    {
                                        type = "ServiceDescription",
                                        id = thing.place2 + "_2",
                                        name = thing.place2 + "_Description",
                                        value = "$none$",
                                        place1 = "$none$",
                                        place2 = "$none$",
                                        foundation = "Individual",
                                        value_type = "$none$"
                                    });

                                    values.Add(new Thing
                                    {
                                        type = "serviceDescribedBy",
                                        id = thing.place2 + "_1",
                                        name = "$none$",
                                        value = "$none$",
                                        place1 = thing.id,
                                        place2 = thing.id + "_2",
                                        foundation = "namedBy",
                                        value_type = "$none$"
                                    });

                                    mandatory_list.AddRange(values);

                                    values = new List<Thing>();

                                    values.Add(new Thing
                                    {
                                        type = "ServiceDescription",
                                        id = thing.place2 + "_2",
                                        name = thing.place2 + "_Description",
                                        value = "$none$",
                                        place1 = "$none$",
                                        place2 = "$none$",
                                        foundation = "Individual",
                                        value_type = "$none$"
                                    });

                                    values5.AddRange(values);

                                    values = new List<Thing>();

                                    values.Add(new Thing
                                    {
                                        type = "serviceDescribedBy",
                                        id = thing.place2 + "_1",
                                        name = "$none$",
                                        value = "$none$",
                                        place1 = thing.id,
                                        place2 = thing.id + "_2",
                                        foundation = "namedBy",
                                        value_type = "$none$"
                                    });

                                    values7.AddRange(values);
                                }
                            }
                            else if (thing.type == "OV-6c")
                            {
                                values = new List<Thing>();
                                if (OV6c_aro_optional_views.TryGetValue(thing.place2, out values))
                                {
                                    optional_list.AddRange(values);
                                }
                            }
                            else if (thing.type == "OV-5b" || thing.type == "OV-6b")
                            {
                                values = new List<Thing>();
                                if (OV5b_aro_optional_views.TryGetValue(thing.place2, out values))
                                {
                                    optional_list.AddRange(values);
                                    mandatory_list.AddRange(OV5b_aro_mandatory_views[thing.place2]);
                                }
                            }
                            else if (thing.type == "DIV-2" || thing.type == "DIV-3")
                            {
                                values = new List<Thing>();
                                if (DIV2_3_optional.TryGetValue(thing.place2, out values))
                                {
                                    if (Correct_Needline(values, view))
                                    {
                                        optional_list.AddRange(values);
                                        values2 = new List<Thing>();
                                        if (DIV2_3_mandatory.TryGetValue(thing.place2, out values2))
                                        {
                                            mandatory_list.AddRange(values2);
                                        }
                                    }
                                }
                            }
                            else if (thing.type == "OV-4")
                            {
                                values = new List<Thing>();
                                if (OV4_support_optional_views.TryGetValue(thing.place2, out values))
                                    if (Allowed_Class("OV-4", (string)thing.value))
                                        optional_list.AddRange(values);
                            }
                            else if (thing.type == "OV-2")
                            {
                                values = new List<Thing>();
                                if (OV2_support_mandatory_views.TryGetValue(thing.place2, out values))
                                    if (Allowed_Class("OV-2", (string)thing.value))
                                        mandatory_list.AddRange(values);
                                values = new List<Thing>();
                                if (OV2_support_optional_views.TryGetValue(thing.place2, out values))
                                    if (Allowed_Class("OV-2", (string)thing.value))
                                        optional_list.AddRange(values);
                            }
                            else if (thing.type == "AV-1" || thing.type.Contains("PV"))
                            {
                                if ((string)thing.value == "ProjectType")
                                {
                                    values = new List<Thing>();

                                    values.Add(new Thing
                                    {
                                        type = "typeInstance",
                                        id = thing.place2 + "_1",
                                        name = "$none$",
                                        value = "$none$",
                                        place1 = thing.id,
                                        place2 = thing.id + "_2",
                                        foundation = "typeInstance",
                                        value_type = "$none$"
                                    });

                                    optional_list.AddRange(values);

                                    values = new List<Thing>();

                                    values.Add(new Thing
                                    {
                                        type = "Project",
                                        id = thing.place2 + "_2",
                                        name = thing.place2 + "_Project",
                                        value = "$none$",
                                        place1 = "$none$",
                                        place2 = "$none$",
                                        foundation = "Individual",
                                        value_type = "$none$"
                                    });

                                    mandatory_list.AddRange(values);

                                    values = new List<Thing>();

                                    values.Add(new Thing
                                    {
                                        type = "typeInstance",
                                        id = thing.place2 + "_1",
                                        name = "$none$",
                                        value = "$none$",
                                        place1 = thing.id,
                                        place2 = thing.id + "_2",
                                        foundation = "typeInstance",
                                        value_type = "$none$"
                                    });

                                    values7.AddRange(values);

                                    values = new List<Thing>();

                                    values.Add(new Thing
                                    {
                                        type = "Project",
                                        id = thing.place2 + "_2",
                                        name = thing.place2 + "_Project",
                                        value = "$none$",
                                        place1 = "$none$",
                                        place2 = "$none$",
                                        foundation = "Individual",
                                        value_type = "$none$"
                                    });

                                    values5.AddRange(values);
                                }
                                if (thing.type == "PV-1")
                                {
                                    if ((string)thing.value == "OrganizationType")
                                    {
                                        values = new List<Thing>();

                                        values.Add(new Thing
                                        {
                                            type = "typeInstance",
                                            id = thing.place2 + "_1",
                                            name = "$none$",
                                            value = "$none$",
                                            place1 = thing.id,
                                            place2 = thing.id + "_2",
                                            foundation = "typeInstance",
                                            value_type = "$none$"
                                        });

                                        optional_list.AddRange(values);

                                        values = new List<Thing>();

                                        values.Add(new Thing
                                        {
                                            type = "Organization",
                                            id = thing.place2 + "_2",
                                            name = thing.place2 + "_Organization",
                                            value = "$none$",
                                            place1 = "$none$",
                                            place2 = "$none$",
                                            foundation = "Individual",
                                            value_type = "$none$"
                                        });

                                        mandatory_list.AddRange(values);

                                        values = new List<Thing>();

                                        values.Add(new Thing
                                        {
                                            type = "typeInstance",
                                            id = thing.place2 + "_1",
                                            name = "$none$",
                                            value = "$none$",
                                            place1 = thing.id,
                                            place2 = thing.id + "_2",
                                            foundation = "typeInstance",
                                            value_type = "$none$"
                                        });

                                        values7.AddRange(values);

                                        values = new List<Thing>();

                                        values.Add(new Thing
                                        {
                                            type = "Organization",
                                            id = thing.place2 + "_2",
                                            name = thing.place2 + "_Organization",
                                            value = "$none$",
                                            place1 = "$none$",
                                            place2 = "$none$",
                                            foundation = "Individual",
                                            value_type = "$none$"
                                        });

                                        values5.AddRange(values);
                                    }
                                }
                            }
                            else if (thing.type == "CV-1")
                            {
                                values = new List<Thing>();
                                if (CV1_mandatory_views.TryGetValue(thing.place2, out values))
                                    mandatory_list.AddRange(values);
                                values = new List<Thing>();
                                if (CV1_optional_views.TryGetValue(thing.place2, out values))
                                    optional_list.AddRange(values);
                            }
                            else if (thing.type == "CV-4")
                            {
                                values = new List<Thing>();
                                if (CV4_mandatory_views.TryGetValue(thing.place2, out values))
                                    mandatory_list.AddRange(values);
                                values = new List<Thing>();
                                if (CV4_optional_views.TryGetValue(thing.place2, out values))
                                    optional_list.AddRange(values);
                            }

                        }
                    }

                    mandatory_list = mandatory_list.GroupBy(x => x.id).Select(grp => grp.First()).ToList();
                    optional_list = optional_list.GroupBy(x => x.id).Select(grp => grp.First()).ToList();

                    values = new List<Thing>();
                    if (doc_blocks_views.TryGetValue(view.First().place1, out values))
                        optional_list.AddRange(values);

                    values = new List<Thing>();
                    if (OV1_pic_views.TryGetValue(view.First().place1, out values))
                        mandatory_list.AddRange(values);

                    mandatory_list = mandatory_list.OrderBy(x => x.type).ToList();
                    optional_list = optional_list.OrderBy(x => x.type).ToList();
                    if (all_view_flag)
                        views.Add(new View { type = view.First().type, id = view.First().place1, name = view.First().name, mandatory = mandatory_list, optional = optional_list });
                    else
                    {
                        if (Proper_View(mandatory_list, view.First().name, view.First().type, view.First().place1, ref errors_list))
                            views.Add(new View { type = view.First().type, id = view.First().place1, name = view.First().name, mandatory = mandatory_list, optional = optional_list });
                    }
                    //else
                    //{
                    //    test = false;
                    //}
                }
            }

            results_dic = null;
            mandatory_list = null;
            optional_list = null;
            view_holder = null;

            //XML Output

            using (var sw = new Utf8StringWriter())
            {
                using (var writer = XmlWriter.Create(sw))
                {

                    writer.WriteRaw(@"<IdeasEnvelope OriginatingNationISO3166TwoLetterCode=""String"" ism:ownerProducer=""NMTOKEN"" ism:classification=""U""
                    xsi:schemaLocation=""http://cio.defense.gov/xsd/dm2 DM2_PES_v2.02_Chg_1.XSD""
                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:ism=""urn:us:gov:ic:ism:v2"" xmlns:ideas=""http://www.ideasgroup.org/xsd""
                    xmlns:dm2=""http://www.ideasgroup.org/dm2""><IdeasData XMLTagsBoundToNamingScheme=""DM2Names"" ontologyVersion=""2.02_Chg_1"" ontology=""DM2"">
		            <NamingScheme ideas:FoundationCategory=""NamingScheme"" id=""ns1""><ideas:Name namingScheme=""ns1"" id=""NamingScheme"" exemplarText=""DM2Names""/>
		            </NamingScheme>");
                    writer.WriteRaw("\n");
                    if (representation_scheme)
                    {
                        writer.WriteRaw(@"<RepresentationScheme ideas:FoundationCategory=""Type"" id=""id_rs1"">
			            <ideas:Name id=""RepresentationScheme"" namingScheme=""ns1"" exemplarText=""Base64 Encoded Image""/>
		                </RepresentationScheme>");
                        writer.WriteRaw("\n");
                    }

                    values = things_dic.Select(kvp => kvp.Value).ToList();
                    things_dic = null;
                    foreach (Thing thing in values)
                        writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id + "\" "
                            + (((string)thing.value_type).Contains("$") ? "" : thing.value_type + "=\"" + (string)thing.value + "\"") + ">" + "<ideas:Name exemplarText=\"" + thing.name
                            + "\" namingScheme=\"ns1\" id=\"n" + thing.id + "\"/></" + thing.type + ">\n");
                    values = null;

                    foreach (Thing thing in values5)
                        writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id + "\" "
                            + (((string)thing.value_type).Contains("$") ? "" : thing.value_type + "=\"" + (string)thing.value + "\"") + ">" + "<ideas:Name exemplarText=\"" + thing.name
                            + "\" namingScheme=\"ns1\" id=\"n" + thing.id + "\"/></" + thing.type + ">\n");
                    values5 = null;

                    foreach (Thing thing in values4)
                        writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id
                        + "\" place1Type=\"id" + thing.place1 + "\" place2Type=\"id" + thing.place2 + "\""
                        + (((string)thing.name).Contains("$") ? "/>\n" : ">" + "<ideas:Name exemplarText=\"" + thing.name
                        + "\" namingScheme=\"ns1\" id=\"n" + thing.id + "\"/></" + thing.type + ">\n"));
                    values4 = null;

                    foreach (Thing thing in values6)
                        writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id
                        + "\" place1Type=\"id" + thing.place1 + "\" place2Type=\"id" + thing.place2 + "\""
                        + (((string)thing.name).Contains("$") ? "/>\n" : ">" + "<ideas:Name exemplarText=\"" + thing.name
                        + "\" namingScheme=\"ns1\" id=\"n" + thing.id + "\"/></" + thing.type + ">\n"));
                    values6 = null;

                    foreach (Thing thing in values3)
                        writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id
                        + "\" tuplePlace1=\"id" + thing.place1 + "\" tuplePlace2=\"id" + thing.place2 + "\""
                        + (((string)thing.name).Contains("$") ? "/>\n" : ">" + "<ideas:Name exemplarText=\"" + thing.name
                        + "\" namingScheme=\"ns1\" id=\"n" + thing.id + "\"/></" + thing.type + ">\n"));
                    values3 = null;

                    foreach (Thing thing in values7)
                        writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id
                        + "\" tuplePlace1=\"id" + thing.place1 + "\" tuplePlace2=\"id" + thing.place2 + "\""
                        + (((string)thing.name).Contains("$") ? "/>\n" : ">" + "<ideas:Name exemplarText=\"" + thing.name
                        + "\" namingScheme=\"ns1\" id=\"n" + thing.id + "\"/></" + thing.type + ">\n"));
                    values7 = null;

                    writer.WriteRaw("</IdeasData>\n");

                    writer.WriteRaw("<IdeasViews frameworkVersion=\"DM2.02_Chg_1\" framework=\"DoDAF\">\n");

                    foreach (View view in views)
                    {
                        writer.WriteRaw("<" + view.type + " id=\"id" + view.id + "\" name=\"" + view.name + "\">\n");

                        writer.WriteRaw("<MandatoryElements>\n");

                        foreach (Thing thing in view.mandatory)
                        {
                            writer.WriteRaw("<" + view.type + "_" + thing.type + " ref=\"id" + thing.id + "\"/>\n");
                        }

                        writer.WriteRaw("</MandatoryElements>\n");
                        writer.WriteRaw("<OptionalElements>\n");

                        foreach (Thing thing in view.optional)
                        {
                            writer.WriteRaw("<" + view.type + "_" + thing.type + " ref=\"id" + thing.id + "\"/>\n");
                        }

                        writer.WriteRaw("</OptionalElements>\n");
                        writer.WriteRaw("</" + view.type + ">\n");
                    }

                    views = null;

                    writer.WriteRaw("</IdeasViews>\n");

                    writer.WriteRaw("</IdeasEnvelope>\n");

                    writer.Flush();
                }

                output = sw.ToString();
                errors = string.Join("", errors_list.Distinct().ToArray());

                if (errors.Count() > 0)
                    test = false;

                return test;
            }
        }

        ////////////////////
        ////////////////////

        public static bool PES2SA(byte[] input, ref string output, ref string errors)
        {
            bool test = true;
            Dictionary<string, Thing> things = new Dictionary<string, Thing>();
            Dictionary<string, Thing> results_dic;
            Dictionary<string, Location> location_dic = new Dictionary<string, Location>();
            IEnumerable<Thing> tuple_types = new List<Thing>();
            IEnumerable<Thing> tuples = new List<Thing>();
            IEnumerable<Thing> results;
            List<View> views = new List<View>();
            string temp = "";
            string temp2 = "";
            string temp3 = "";
            string date = DateTime.Now.ToString("d");
            string time = DateTime.Now.ToString("T");
            string prop_date = DateTime.Now.ToString("yyyyMMdd");
            string prop_time = DateTime.Now.ToString("HHmmss");
            string minor_type;
            string minor_type_name;
            Guid view_GUID;
            Guid thing_GUID;
            Guid temp_GUID;
            Dictionary<string, Guid> thing_GUIDs = new Dictionary<string, Guid>();
            Dictionary<string, Thing> OV1_pic_views;
            Dictionary<string, List<Thing>> CV4_CD_views;
            Dictionary<string, List<Thing>> ARO_views;
            Dictionary<string, Thing> doc_block_views;
            Dictionary<string, List<Thing>> support_views;
            Dictionary<string, List<Thing>> needline_views;
            List<string> SA_Def_elements = new List<string>();
            XElement root = XElement.Load(new MemoryStream(input));
            List<List<Thing>> sorted_results;
            //bool representation_scheme = false;
            int count = 0;
            int count2 = 0;
            string loc_x, loc_y, size_x, size_y;
            Thing value;
            List<Thing> values;
            XNamespace ns = "http://www.ideasgroup.org/xsd";
            Location location;
            List<string> errors_list = new List<string>();
            Dictionary<string, List<Thing>> tuple_types_dic1;
            Dictionary<string, List<Thing>> tuple_types_dic2;

            // regular Things

            foreach (string[] current_lookup in Element_Lookup)
            {
                if (current_lookup[5] != "default")
                    continue;
                //if (current_lookup[0] == "ArchitecturalDescription")
                //{
                //    results =
                //      from result in root.Elements("Class").Elements("SADiagram").Elements("SASymbol").Elements("SAPicture")
                //      where (string)result.Parent.Attribute("SAObjMinorTypeName") == "Picture"
                //      where (from diagram in result.Parent.Parent.Parent.Elements("SADefinition")
                //             where (string)diagram.Attribute("SAObjId") == (string)result.Parent.Attribute("SASymIdDef")
                //             select diagram
                //         ).Any()
                //      select new Thing
                //      {
                //          type = "ArchitecturalDescription",
                //          id = (string)result.Parent.Attribute("SASymIdDef"),
                //          name = (string)result.Parent.Attribute("SAObjName"),
                //          value = (string)result.Attribute("SAPictureData"),
                //          place1 = "$none$",
                //          place2 = "$none$",
                //          foundation = "IndividualType",
                //          value_type = "exemplarText"
                //      };

                //    //if (results.Count() > 0)
                //        //representation_scheme = true;
                //}
                //else
                //{

                results =
                    from result in root.Elements("IdeasData").Descendants().Elements(ns + "Name")
                    where (string)result.Parent.Name.ToString() == current_lookup[0]
                    select new Thing
                        {
                            type = current_lookup[0],
                            id = ((string)result.Parent.Attribute("id")).Substring(2),
                            name = (string)result.Attribute("exemplarText"),
                            value = current_lookup[1],
                            place1 = "$none$",
                            place2 = "$none$",
                            foundation = (string)result.Parent.Attribute(ns + "FoundationCategory"),
                            value_type = "SAObjMinorTypeName"
                        };

                results_dic =
                    (from result in root.Elements("IdeasData").Descendants().Elements(ns + "Name")
                     where (string)result.Parent.Name.ToString() == current_lookup[0]
                     select new
                     {
                         key = ((string)result.Parent.Attribute("id")).Substring(2),
                         value = new Thing
                         {
                             type = current_lookup[0],
                             id = ((string)result.Parent.Attribute("id")).Substring(2),
                             name = (string)result.Attribute("exemplarText"),
                             value = current_lookup[1],
                             place1 = "$none$",
                             place2 = "$none$",
                             foundation = (string)result.Parent.Attribute(ns + "FoundationCategory"),
                             value_type = "SAObjMinorTypeName"
                         }
                     }).ToDictionary(a => a.key, a => a.value);
                //}

                if (results_dic.Count() > 0)
                    MergeDictionaries(things, results_dic);
            }

            //  diagramming

            results =
                     from result in root.Elements("IdeasData").Elements("SpatialMeasure").Elements(ns + "Name")
                     select new Thing
                         {
                             id = ((string)result.Parent.Attribute("id")).Substring(2, ((string)result.Parent.Attribute("id")).Length - 5),
                             name = (string)result.Attribute("exemplarText"),
                             value = (string)result.Parent.Attribute("numericValue"),
                             place1 = "$none$",
                             place2 = "$none$",
                             foundation = "$none$",
                             value_type = "diagramming"
                         };

            sorted_results = results.GroupBy(x => x.id).Select(group => group.OrderBy(x => x.name).ToList()).ToList();

            foreach (List<Thing> coords in sorted_results)
            {
                location_dic.Add(coords.First().id,
                    new Location
                    {
                        id = coords.First().id,
                        bottom_right_x = (string)coords[0].value,
                        bottom_right_y = (string)coords[1].value,
                        bottom_right_z = "0",
                        top_left_x = (string)coords[3].value,
                        top_left_y = (string)coords[4].value,
                        top_left_z = "0",
                    });
            }

            // doc block

            results =
                    from result in root.Elements("IdeasData").Elements("Information")
                    from result2 in root.Elements("IdeasData").Elements("describedBy")
                    where ((string)result2.Attribute("tuplePlace2")).Substring(2) == ((string)result.Attribute("id")).Substring(2)
                    select new Thing
                    {
                        type = "Information",
                        id = ((string)result.Attribute("id")).Substring(2),
                        name = (string)result.Attribute("exemplarText"),
                        value = "$none$",
                        place1 = "$none$",
                        place2 = "$none$",
                        foundation = "IndividualType",
                        value_type = "$none$"
                    };
            if (results.Count() > 0)
            {
                foreach (Thing thing in results)
                {
                    things.Remove(thing.id);
                }
            }

            doc_block_views =
                   (from result in root.Elements("IdeasData").Descendants().Elements(ns + "Name")
                    where (string)result.Attribute("exemplarText") == "Doc Block Comment"
                    from result2 in root.Elements("IdeasViews").Descendants().Descendants().Descendants()
                    where (string)result2.Parent.Parent.Name.ToString() != "AV-2"
                    where ((string)result2.Attribute("ref")).Substring(2) == ((string)result.Parent.Attribute("id")).Substring(2)
                    select new
                    {
                        key = ((string)result2.Parent.Parent.Attribute("id")).Substring(2),
                        value = new Thing
                        {
                            type = "$none$",
                            id = ((string)result.Parent.Attribute("id")).Substring(2),
                            name = (string)result.Attribute("exemplarText"),
                            value = ((string)result.Parent.Attribute("exemplarText")),
                            place1 = "$none$",
                            place2 = "$none$",
                            foundation = "$none$",
                            value_type = "Comment"
                        }
                    }).ToDictionary(a => a.key, a => a.value);

            ////Support

            //results =
            //         from result5 in root.Elements("IdeasViews").Descendants().Descendants().Descendants()
            //         where ((string)result5.Parent.Parent.Attribute("id")).Substring(2) != "_1"
            //         where ((string)result5.Parent.Parent.Attribute("id")).Substring(2) != "_2"
            //         from result in root.Elements("IdeasData").Elements("activityPerformedByPerformer")
            //         where ((string)result5.Attribute("ref")).Substring(2) == ((string)result.Attribute("place1Type")).Substring(2)
            //         from result2 in root.Elements("IdeasData").Elements("activityConsumesResource").Elements(ns + "Name")
            //         where ((string)result2.Attribute("exemplarText") == "Support")
            //         where ((string)result.Parent.Attribute("place2Type")).Substring(2) == ((string)result2.Parent.Attribute("place2Type")).Substring(2)
            //         from result6 in root.Elements("IdeasData").Elements("Resource")
            //         where ((string)result6.Attribute("id")).Substring(2) == ((string)result2.Parent.Attribute("place1Type")).Substring(2)
            //         from result3 in root.Elements("IdeasData").Elements("activityProducesResource")
            //         where ((string)result2.Parent.Attribute("place1Type")).Substring(2) == ((string)result3.Attribute("place2Type")).Substring(2)
            //         from result4 in root.Elements("IdeasData").Elements("activityPerformedByPerformer")
            //         where ((string)result3.Attribute("place1Type")).Substring(2) == ((string)result4.Attribute("place2Type")).Substring(2)

            //         select new Thing
            //        {
            //            type = "SupportedBy",
            //            id = ((string)result.Attribute("place1Type")).Substring(2) + ((string)result4.Attribute("place1Type")).Substring(2),
            //            name = "$none$",
            //            value = ((string)result5.Parent.Parent.Attribute("id")).Substring(2),
            //            place1 = ((string)result.Attribute("place1Type")).Substring(2),
            //            place2 = ((string)result4.Attribute("place1Type")).Substring(2),
            //            foundation = "$none$",
            //            value_type = "View ID"
            //        };

            //support_views = results.GroupBy(x => (string)x.value)
            //                 .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

            //if (results.Count() > 0)
            //{
            //    foreach (Thing thing in results)
            //    {
            //        things.Remove(thing.place1 + "_2");
            //        things.Remove(thing.place2 + "_2");
            //        things.Remove(thing.place1 + "_3");
            //        things.Remove(thing.place2 + "_3");
            //    }
            //}

            //// Needlines and System Resource Flow

            //results =
            //         from result5 in root.Elements("IdeasViews").Descendants().Descendants().Descendants()
            //         where ((string)result5.Parent.Parent.Attribute("id")).Substring(2) != "_1"
            //         where ((string)result5.Parent.Parent.Attribute("id")).Substring(2) != "_2"
            //         from result in root.Elements("IdeasData").Elements("activityPerformedByPerformer").Elements(ns + "Name")
            //         where ((string)result5.Attribute("ref")).Substring(2) == ((string)result.Parent.Attribute("place1Type")).Substring(2)
            //         from result2 in root.Elements("IdeasData").Elements("activityConsumesResource").Elements(ns + "Name")
            //         where ((string)result2.Attribute("exemplarText") == "Needline") || ((string)result2.Attribute("exemplarText") == "SF")
            //         where ((string)result.Parent.Attribute("place2Type")).Substring(2) == ((string)result2.Parent.Attribute("place2Type")).Substring(2)
            //         from result6 in root.Elements("IdeasData").Elements("Resource")
            //         where ((string)result6.Attribute("id")).Substring(2) == ((string)result2.Parent.Attribute("place1Type")).Substring(2)
            //         from result3 in root.Elements("IdeasData").Elements("activityProducesResource")
            //         where ((string)result2.Parent.Attribute("place1Type")).Substring(2) == ((string)result3.Attribute("place2Type")).Substring(2)
            //         from result4 in root.Elements("IdeasData").Elements("activityPerformedByPerformer")
            //         where ((string)result3.Attribute("place1Type")).Substring(2) == ((string)result4.Attribute("place2Type")).Substring(2)

            //         select new Thing
            //         {
            //             type =
            //             Resource_Flow_Type(
            //             (string)result2.Attribute("exemplarText"), (string)result5.Parent.Parent.Name.ToString(), ((string)result.Parent.Attribute("place1Type")).Substring(2), ((string)result4.Attribute("place1Type")).Substring(2), things
            //             ),
            //             id = ((string)result2.Attribute("id")).Substring(1, ((string)result2.Attribute("id")).Length - 3),
            //             name = ((string)result.Attribute("exemplarText")),
            //             value = ((string)result5.Parent.Parent.Attribute("id")).Substring(2),
            //             place1 = ((string)result.Parent.Attribute("place1Type")).Substring(2),
            //             place2 = ((string)result4.Attribute("place1Type")).Substring(2),
            //             foundation = "$none$",
            //             value_type = "View ID"
            //         };

            //needline_views = results.GroupBy(x => (string)x.value)
            //                 .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

            //if (results.Count() > 0)
            //{
            //    foreach (Thing thing in needline_views.First().Value)
            //    {
            //        things.Remove(thing.id + "_1");
            //        things.Remove(thing.id + "_2");
            //        things.Remove(thing.id + "_4");
            //        things.Add(thing.id, thing);
            //    }
            //}

            //// Capability Dependency

            //results =
            //       from result2 in root.Elements("IdeasViews").Descendants().Descendants().Descendants()
            //       where (string)result2.Name.ToString() == "CV-4_BeforeAfterType"
            //       from result in root.Elements("IdeasData").Descendants().Elements(ns + "Name")
            //       where ((string)result2.Attribute("ref")).Substring(2) == ((string)result.Parent.Attribute("id")).Substring(2)
            //       select new Thing
            //           {
            //               type = "Capability Dependency (DM2rx)",
            //               id = ((string)result.Parent.Attribute("id")).Substring(2),
            //               name = (string)result.Attribute("exemplarText"),
            //               value = ((string)result2.Parent.Parent.Attribute("id")).Substring(2),
            //               place1 = ((string)result.Parent.Attribute("place1Type")).Substring(2),
            //               place2 = ((string)result.Parent.Attribute("place2Type")).Substring(2),
            //               foundation = "$none$",
            //               value_type = "View ID"
            //           };

            //CV4_CD_views = results.GroupBy(x => (string)x.value)
            //                 .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

            //if (CV4_CD_views.Count() > 0)
            //{
            //    foreach (Thing thing in CV4_CD_views.First().Value)
            //    {
            //        things.Remove(thing.id);
            //    }
            //}

            ////ARO

            //results =
            //       from result5 in root.Elements("IdeasViews").Descendants().Descendants().Descendants()
            //       where ((string)result5.Parent.Parent.Attribute("id")).Substring(2) != "_1"
            //       where ((string)result5.Parent.Parent.Attribute("id")).Substring(2) != "_2"
            //       from result2 in root.Elements("IdeasData").Elements("activityConsumesResource").Elements(ns + "Name")
            //       where ((string)result2.Attribute("exemplarText") == "ARO")
            //       where ((string)result5.Attribute("ref")).Substring(2) == ((string)result2.Parent.Attribute("place1Type")).Substring(2)
            //       from result6 in root.Elements("IdeasData").Elements("Resource").Elements(ns + "Name")
            //       where ((string)result6.Parent.Attribute("id")).Substring(2) == ((string)result2.Parent.Attribute("place1Type")).Substring(2)
            //       from result3 in root.Elements("IdeasData").Elements("activityProducesResource")
            //       where ((string)result2.Parent.Attribute("place1Type")).Substring(2) == ((string)result3.Attribute("place2Type")).Substring(2)
            //       select new Thing
            //       {
            //           type = "ActivityResourceOverlap (DM2r)",
            //           id = ((string)result3.Attribute("id")).Substring(2, ((string)result3.Attribute("id")).Length - 4),
            //           name = ((string)result6.Attribute("exemplarText")),
            //           value = ((string)result5.Parent.Parent.Attribute("id")).Substring(2),
            //           place1 = ((string)result3.Attribute("place1Type")).Substring(2),
            //           place2 = ((string)result2.Parent.Attribute("place2Type")).Substring(2),
            //           foundation = "$none$",
            //           value_type = "View ID"
            //       };

            //ARO_views = results.GroupBy(x => (string)x.value)
            //                 .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

            //if (ARO_views.Count() > 0)
            //{
            //    foreach (Thing thing in ARO_views.First().Value)
            //    {
            //        things.Remove(thing.id + "_1");
            //        things.Remove(thing.id + "_2");
            //        things.Remove(thing.id + "_3");
            //    }
            //}

            // OV-1 Pic

            //OV1_pic_views =
            //       (
            //        from result2 in root.Elements("IdeasViews").Descendants().Descendants().Descendants()
            //        where (string)result2.Name.ToString() == "OV-1_ArchitecturalDescription"
            //        from result in root.Elements("IdeasData").Descendants().Elements(ns + "Name")
            //        where ((string)result2.Attribute("ref")).Substring(2) == ((string)result.Parent.Attribute("id")).Substring(2)
            //        from result3 in root.Elements("IdeasData").Elements("representationSchemeInstance")
            //        //where (string)result.Parent.Name.ToString() == "ArchitecturalDescription"
            //        where ((string)result3.Attribute("tuplePlace2")).Substring(2) == ((string)result.Parent.Attribute("id")).Substring(2)
            //        select new
            //        {
            //            key = ((string)result2.Parent.Parent.Attribute("id")).Substring(2),
            //            value = new Thing
            //            {
            //                type = "ArchitecturalDescription",
            //                id = ((string)result.Parent.Attribute("id")).Substring(2),
            //                name = (string)result.Attribute("exemplarText"),
            //                value = ((string)result.Parent.Attribute("exemplarText")),
            //                place1 = "$none$",
            //                place2 = "$none$",
            //                foundation = (string)result.Parent.Attribute(ns + "FoundationCategory"),
            //                value_type = "Picture"
            //            }
            //        }).ToDictionary(a => a.key, a => a.value);

            //if (OV1_pic_views.Count() > 0)
            //{
            //    foreach (Thing thing in OV1_pic_views.Values.ToList())
            //    {
            //        things.Remove(thing.id);
            //    }
            //}

            //// regular tuples

            //foreach (string[] current_lookup in Tuple_Lookup)
            //{
            //    if (current_lookup[3] != "1" && current_lookup[3] != "5")
            //        continue;

            //    results =
            //        from result in root.Elements("IdeasData").Descendants()
            //        where (string)result.Name.ToString() == current_lookup[0]
            //        from result2 in root.Elements("IdeasData").Descendants()
            //        where ((string)result.Attribute("tuplePlace1")) == ((string)result2.Attribute("id"))
            //        where (string)result2.Name.ToString() == current_lookup[5]
            //        select new Thing
            //        {
            //            type = current_lookup[0],
            //            id = ((string)result.Attribute("id")).Substring(2),
            //            name = "$none$",
            //            value = (string)result2.Name.ToString(),
            //            place1 = ((string)result.Attribute("tuplePlace1")).Substring(2),
            //            place2 = ((string)result.Attribute("tuplePlace2")).Substring(2),
            //            foundation = current_lookup[2],
            //            value_type = "element type"
            //        };

            //    tuples = tuples.Concat(results.ToList());
            //}

            // regular tuple types

            foreach (string[] current_lookup in Tuple_Type_Lookup)
            {

                if (current_lookup[3] != "1" && current_lookup[3] != "5")
                    continue;

                results =
                    from result in root.Elements("IdeasData").Descendants()
                    where (string)result.Name.ToString() == current_lookup[0]
                    from result2 in root.Elements("IdeasData").Descendants()
                    where ((string)result.Attribute("place1Type")) == ((string)result2.Attribute("id"))
                    where (string)result2.Name.ToString() == current_lookup[5]

                    select new Thing
                    {
                        type = current_lookup[0],
                        id = ((string)result.Attribute("id")).Substring(2),
                        name = "$none$",
                        value = (string)result2.Name.ToString(),
                        place1 = ((string)result.Attribute("place1Type")).Substring(2),
                        place2 = ((string)result.Attribute("place2Type")).Substring(2),
                        foundation = current_lookup[2],
                        value_type = "element type"
                    };

                tuple_types = tuple_types.Concat(results.ToList());
            }

            tuple_types_dic1 = tuple_types.Where(x => x.type == "WholePartType").GroupBy(x => x.place1).ToDictionary(x => x.Key, x => x.ToList());
            tuple_types_dic2 = tuple_types.Where(x => x.type == "WholePartType").GroupBy(x => x.place2).ToDictionary(x => x.Key, x => x.ToList());

            // views

            foreach (string[] current_lookup in View_Lookup)
            {
                if (current_lookup[3] != "default")
                    continue;
                results =
                    from result in root.Elements("IdeasViews").Descendants().Descendants().Descendants()
                    where (string)result.Parent.Parent.Name.ToString() == current_lookup[0]
                    select new Thing
                    {
                        type = current_lookup[0],
                        id = ((string)result.Parent.Parent.Attribute("id")).Substring(2) + ((string)result.Attribute("ref")).Substring(2),
                        name = ((string)result.Parent.Parent.Attribute("name")).Replace("&", " And "),
                        place1 = ((string)result.Parent.Parent.Attribute("id")).Substring(2),
                        place2 = ((string)result.Attribute("ref")).Substring(2),
                        value = (things.TryGetValue(((string)result.Attribute("ref")).Substring(2), out value)) ? value : new Thing { type = "$none$" },
                        foundation = "$none$",
                        value_type = "Thing"
                    };


                sorted_results = results.GroupBy(x => x.name).Select(group => group.Distinct().ToList()).ToList();
                //sorted_results = Add_Tuples(sorted_results, tuples);
                //sorted_results = Add_Tuples(sorted_results, tuple_types);

                foreach (List<Thing> view in sorted_results)
                {
                    List<Thing> mandatory_list = new List<Thing>();
                    List<Thing> optional_list = new List<Thing>();

                    foreach (Thing thing in view)
                    {

                        temp = Find_Mandatory_Optional((string)((Thing)thing.value).type, view.First().name, thing.type, thing.place1, ref errors_list);
                        if (temp == "Mandatory")
                        {
                            mandatory_list.Add(new Thing { id = thing.place2, name = (string)((Thing)thing.value).name, type = (string)((Thing)thing.value).value });
                        }
                        if (temp == "Optional")
                        {
                            optional_list.Add(new Thing { id = thing.place2, name = (string)((Thing)thing.value).name, type = (string)((Thing)thing.value).value });
                        }
                    }

                    mandatory_list = mandatory_list.OrderBy(x => x.type).ToList();
                    optional_list = optional_list.OrderBy(x => x.type).ToList();

                    //if (needline_views.TryGetValue(view.First().place1, out values))
                    //    optional_list.AddRange(values);

                    //if (CV4_CD_views.TryGetValue(view.First().place1, out values))
                    //    optional_list.AddRange(values);

                    //if (ARO_views.TryGetValue(view.First().place1, out values))
                    //    optional_list.AddRange(values);

                    //if (Proper_View(mandatory_list, view.First().type))
                    views.Add(new View { type = current_lookup[1], id = view.First().place1, name = view.First().name, mandatory = mandatory_list, optional = optional_list });
                }
            }

            // output

            foreach (string thing in things.Keys)
            {
                thing_GUID = Guid.NewGuid();
                thing_GUIDs.Add(thing, thing_GUID);
            }

            using (var sw = new Utf8StringWriter())
            {
                using (var writer = XmlWriter.Create(sw))
                {

                    writer.WriteRaw(@"<Classes>");

                    foreach (View view in views)
                    {
                        count2 = 0;
                        count++;
                        view_GUID = Guid.NewGuid();
                        minor_type = Find_View_SA_Minor_Type(view.type);

                        writer.WriteRaw("<Class><SADiagram SAObjId=\"" + view.id + "\" SAObjName=\"" + view.name + "\" SAObjMinorTypeName=\"" + view.type
                            + "\" SAObjMinorTypeNum=\"" + minor_type + "\" SAObjMajorTypeNum=\"1\" SAObjAuditId=\"NEAR\" SAObjUpdateDate=\""
                            + date + "\" SAObjUpdateTime=\"" + time + "\" SAObjFQName=\"" + view.name + "\" "
                            + "SADgmCLevelNumber=\"\" SADgmSnapGridEnt=\"0\" SADgmSnapGridLin=\"0\" SADgmPGridNumEnt=\"4 4\" SADgmPGridNumLin=\"10 10\""
                            + " SADgmPGridSizeEnt=\"25 25\" SADgmPGridSizeLin=\"10 10\" SADgmGridUnit100=\"100 100\" SADgmBPresentationMenu=\"0\""
                            + " SADgmBShowPages=\"0\" SADgmBShowRuler=\"0\" SADgmBShowGrid=\"-1\" SADgmBShowScroll=\"-1\" SADgmBShowNodeShadow=\"-1\""
                            + " SADgmBShowLineShadow=\"0\" SADgmBShowTextShadow=\"0\" SADgmPShadowDelta=\"5 5\" SADgmRGBShadowColor=\"0x00c0c0c0\""
                            + " SADgmRMargin=\"50 50 50 50\" SADgmBBorder=\"0\" SADgmBorderOffset=\"-13\" SADgmWBorderPenStyle=\"0x0010\" SADgmBDgmBorder=\"0\""
                            + " SADgmIDgmForm=\"0\" SADgmWOrientation=\"0x0003\" SADgmBDgmPDefault=\"1\" SADgmBIsHierarchy=\"0\" SADgmBBackgroundColorOn=\"0\""
                            + " SADgmRGBBackgroundColor=\"0x00ffffff\" SADgmWLinePenStyle=\"0x0103\">");

                        writer.WriteRaw("<SAProperty SAPrpName=\"~C~\" SAPrpValue=\"1\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                            + "<SAProperty SAPrpName=\"~T~\" SAPrpValue=\"" + minor_type + "\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                            + "<SAProperty SAPrpName=\"Use Automatic Gradient Fills\" SAPrpValue=\"T\" SAPrpEditType=\"4\" SAPrpLength=\"1\"/>"
                            + "<SAProperty SAPrpName=\"DGX File Name\" SAPrpValue=\"D" + count.ToString("D7") + ".DGX\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                            //+ ((minor_type == "283") ? "" : "<SAProperty SAPrpName=\"Hierarchical Numbering\" SAPrpValue=\"F\" SAPrpEditType=\"4\" SAPrpLength=\"1\"/>") 
                            + "<SAProperty SAPrpName=\"Initial Date\" SAPrpValue=\"" + prop_date + "\" SAPrpEditType=\"2\" SAPrpLength=\"10\"/>"
                            + "<SAProperty SAPrpName=\"Initial Time\" SAPrpValue=\"" + prop_time + "\" SAPrpEditType=\"7\" SAPrpLength=\"11\"/>"
                            + "<SAProperty SAPrpName=\"Initial Audit\" SAPrpValue=\"NEAR\" SAPrpEditType=\"1\" SAPrpLength=\"8\"/>"
                            + "<SAProperty SAPrpName=\"GUID\" SAPrpValue=\"" + view_GUID + "\" SAPrpEditType=\"1\" SAPrpLength=\"64\"/>"
                            // + "<SAProperty SAPrpName=\"Description\" SAPrpValue=\"\" SAPrpEditType=\"1\" SAPrpLength=\"4074\"/>"
                            //+ "<SAProperty SAPrpName=\"Vertical Pools and Lanes\" SAPrpValue=\"F\" SAPrpEditType=\"4\" SAPrpLength=\"1\"/>"
                            //+ "<SAProperty SAPrpName=\"Check Connections\" SAPrpValue=\"F\" SAPrpEditType=\"4\" SAPrpLength=\"1\"/>"
                            //+ "<SAProperty SAPrpName=\"Auto-create/update 1380\" SAPrpValue=\"T\" SAPrpEditType=\"4\" SAPrpLength=\"1\"/>"
                            //+ "<SAProperty SAPrpName=\"Auto-populate Where of APBP\" SAPrpValue=\"T\" SAPrpEditType=\"4\" SAPrpLength=\"1\"/>"
                            //+ "<SAProperty SAPrpName=\"Peers\" SAPrpValue=\"\" SAPrpEditType=\"14\" SAPrpLength=\"1200\" SAPrpEditDefMajorType=\"Diagram\"" 
                            //+ " SAPrpEditDefMinorType=\"" + view.type + "\"/>"
                            //+ "<SAProperty SAPrpName=\"Architecture Type\" SAPrpValue=\"\" SAPrpEditType=\"1\" SAPrpLength=\"1200\"/>"
                            //+ "<SAProperty SAPrpName=\"Related Architecture Description\" SAPrpValue=\"\" SAPrpEditType=\"14\" SAPrpLength=\"1200\""
                            //+ " SAPrpEditDefMajorType=\"Definition\" SAPrpEditDefMinorType=\"ArchitecturalDescription (DM2)\"/>"
                            //+ "<SAProperty SAPrpName=\"OSLCLink\" SAPrpValue=\"\" SAPrpEditType=\"8\" SAPrpLength=\"4074\" SAPrpEditDefMajorType=\"Definition\""
                            //+ " SAPrpEditDefMinorType=\"OSLC Link\"/>"
                            //+ "<SAProperty SAPrpName=\"Reference Documents\" SAPrpValue=\"\" SAPrpEditType=\"18\" SAPrpLength=\"1024\"/>"
                            + "<SAProperty SAPrpName=\"SA VISIO Last Modified By\" SAPrpValue=\"SA\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                            + "<SAProperty SAPrpName=\"Last Change Date\" SAPrpValue=\"" + DateTime.Now.ToString("yyyyMMdd") + "\" SAPrpEditType=\"2\" SAPrpLength=\"10\"/>"
                            + "<SAProperty SAPrpName=\"Last Change Time\" SAPrpValue=\"" + DateTime.Now.ToString("HHmmss") + "\" SAPrpEditType=\"7\" SAPrpLength=\"11\"/>"
                            + "<SAProperty SAPrpName=\"Last Change Audit\" SAPrpValue=\"NEAR\" SAPrpEditType=\"1\" SAPrpLength=\"8\"/>");

                        List<Thing> thing_list = new List<Thing>(view.mandatory);
                        thing_list.AddRange(view.optional);

                        foreach (Thing thing in thing_list)
                        {
                            if (view.type == "DIV-02 Logical Data Model (Entity Relation) (DM2)")
                                thing.type = Find_DIV2_Type(thing, ref tuple_types_dic1, ref tuple_types_dic2);

                            if (view.type == "SV-08 Systems Evolution Description (DM2)" && thing.type == "Activity (DM2)")
                                thing.type = "System Milestone (DM2x)";

                            if (view.type == "PV-02 Project Timelines (DM2)")
                                thing.type = "Project Milestone (DM2x)";


                            if (thing_GUIDs.TryGetValue(thing.id, out thing_GUID) == false)
                            {
                                thing_GUID = Guid.NewGuid();
                                thing_GUIDs.Add(thing.id, thing_GUID);
                            }

                            if (location_dic.TryGetValue(view.id + thing.id, out location) == true)
                            {
                                loc_x = location.top_left_x;
                                loc_y = location.top_left_y;
                                size_x = (Convert.ToInt32(location.bottom_right_x) - Convert.ToInt32(location.top_left_x)).ToString();
                                size_y = (Convert.ToInt32(location.top_left_y) - Convert.ToInt32(location.bottom_right_y)).ToString();
                            }
                            else
                            {
                                loc_x = "574";
                                loc_y = "203";
                                size_x = "125";
                                size_y = "55";
                            }

                            if (view.type == "SV-08 Systems Evolution Description (DM2)" && thing.type == "System Milestone (DM2x)")
                                minor_type_name = "Milestone";
                            else
                                minor_type_name = thing.type;

                            minor_type = Find_Symbol_Element_SA_Minor_Type(ref minor_type_name, view.type);

                            if (view.type == "DIV-02 Logical Data Model (Entity Relation) (DM2)" && thing.type != "Entity")
                                continue;

                            writer.WriteRaw("<SASymbol SAObjId=\"" + thing.id + view.id.Substring(1) + "\" SAObjName=\"" + thing.name + "\" SAObjMinorTypeName=\"" + minor_type_name + "\""
                                + " SAObjMinorTypeNum=\"" + minor_type + "\" SAObjMajorTypeNum=\"2\" SAObjAuditId=\"NEAR\" SAObjUpdateDate=\"" + date + "\""
                                + " SAObjUpdateTime=\"" + time + "\" SAObjFQName=\"&quot;" + thing_GUID + "&quot;.&quot;" + thing.name + "&quot;\" SASymIdDgm=\"" + view.id + "\" SASymIdDef=\"" + thing.id + "\""
                                //other
                                + " SASymArrangement=\"0\" SASymOtherSymbology=\"0\" SASymProperties=\"0x0000\" SASymOrder=\"0\" SASymXPEntity=\"" + count2 + "\""
                                + " SASymXPLink=\"65535\" SASymXPGroup=\"65535\" SASymXPSibling=\"65535\" SASymXPSubordinate=\"65535\" SASymPenStyle=\"0x0010\""
                                + " SASymFontName=\"\" SASymFontHeight=\"0x0000\" SASymFontFlags=\"0x0000\" SASymLineStyle=\"0x0103\" SASymFlags=\"0x0002\""
                                + " SASymFlags2=\"0x0000\" SASymFlags3=\"0x0000\" SASymTextFlags=\"0x082a\" SASymStyle=\"0\" SASymAuxStyle=\"0x0000\""
                                + " SASymOccurs=\"0x01\" SASymOccOffset=\"0x00\" SASymBGColor=\"0x00\" SASymFGColor=\"0x00\" SASymPrompt=\"0x00\""
                                + " SASymFrExArcChar=\"0x00\" SASymToExArcChar=\"0x00\" SASymUncleCount=\"0x00\" SASymStyleFlags=\"0x0007\" SASymSeqNum=\"0\""
                                + " SASymRotation=\"0\" SASymError1=\"0x00\" SASymError2=\"0x00\" SASymHideProgeny=\"0\" SASymHidden=\"0\" SASymOtherForm=\"0\""
                                + " SASymHasDspMode=\"0\" SASymDspMode=\"0x0000\" SASymDspModeExt=\"0x00000000\" SASymCLevelNumber=\"0\" SASymPenColorOn=\"1\""
                                + " SASymPenColorRed=\"0\" SASymPenColorGreen=\"130\" SASymPenColorBlue=\"236\" SASymFillColorOn=\"1\" SASymFillColorRed=\"176\""
                                + " SASymFillColorGreen=\"213\" SASymFillColorBlue=\"255\" SASymFontColorOn=\"1\" SASymFontColorRed=\"0\" SASymFontColorGreen=\"0\""
                                + " SASymFontColorBlue=\"0\" SASymLocX=\"" + loc_x + "\" SASymLocY=\"" + loc_y + "\" SASymSizeX=\"" + size_x + "\" SASymSizeY=\"" + size_y + "\" SASymNameLocX=\"572\""
                                + " SASymNameLocY=\"168\" SASymNameSizeX=\"121\" SASymNameSizeY=\"18\" SASymDescLocX=\"0\" SASymDescLocY=\"0\" SASymDescSizeX=\"0\""
                                + " SASymDescSizeY=\"0\">");

                            writer.WriteRaw("<SAProperty SAPrpName=\"~C~\" SAPrpValue=\"2\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                                + "<SAProperty SAPrpName=\"~T~\" SAPrpValue=\"" + minor_type + "\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                                + "<SAProperty SAPrpName=\"Object Class Number\" SAPrpValue=\"3\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                                + "<SAProperty SAPrpName=\"Object Type Number\" SAPrpValue=\"" + Find_Definition_Element_SA_Minor_Type(thing.type) + "\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                                + "<SAProperty SAPrpName=\"Symbol Represents\" SAPrpValue=\"" + thing.type + "\" SAPrpEditType=\"1\" SAPrpLength=\"4074\"/>"
                                + "<SAProperty SAPrpName=\"KeyGUID\" SAPrpValue=\"" + thing_GUID + "\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                                //+ "<SARelation SARelId=\"_1982\" SARelTypeNum=\"6\" SARelTypeName=\"connects\"/>"
                                //+ "<SARelation SARelId=\"_1980\" SARelTypeNum=\"8\" SARelTypeName=\"connects\"/>"
                                //+ "<SARelation SARelId=\"_1979\" SARelTypeNum=\"28\" SARelTypeName=\"embeds\"/>"
                                //+ "<SARelation SARelId=\"_1991\" SARelTypeNum=\"28\" SARelTypeName=\"embeds\"/>"
                                + "</SASymbol>");

                            count2++;
                        }

                        //if (OV1_pic_views.TryGetValue(view.id, out value))
                        //{

                        //    if (location_dic.TryGetValue(view.id + value.id, out location) == true)
                        //    {
                        //        loc_x = location.top_left_x;
                        //        loc_y = location.top_left_y;
                        //        size_x = (Convert.ToInt32(location.bottom_right_x) - Convert.ToInt32(location.top_left_x)).ToString();
                        //        size_y = (Convert.ToInt32(location.top_left_y) - Convert.ToInt32(location.bottom_right_y)).ToString();
                        //    }
                        //    else
                        //    {
                        //        loc_x = "574";
                        //        loc_y = "203";
                        //        size_x = "125";
                        //        size_y = "55";
                        //    }

                        //    writer.WriteRaw("<SASymbol SAObjId=\"" + value.id + "\" SAObjName=\"" + value.name + "\" SAObjMinorTypeName=\"Picture\" SAObjMinorTypeNum=\"11\" SAObjMajorTypeNum=\"2\" SAObjAuditId=\"ir\""
                        //        + " SAObjUpdateDate=\"2/5/2015\" SAObjUpdateTime=\"10:00:16 AM\" SAObjFQName=\"&quot;&quot;\" SASymIdDgm=\"" + view.id + "\" SASymArrangement=\"0\" SASymOtherSymbology=\"0\""
                        //        + " SASymProperties=\"0x0000\" SASymOrder=\"0\" SASymXPEntity=\"1\" SASymXPLink=\"65535\" SASymXPGroup=\"65535\" SASymXPSibling=\"65535\" SASymXPSubordinate=\"65535\""
                        //        + " SASymPenStyle=\"0x0010\" SASymFontName=\"\" SASymFontHeight=\"0x0000\" SASymFontFlags=\"0x0000\" SASymLineStyle=\"0x0103\" SASymFlags=\"0x0002\" SASymFlags2=\"0x0000\""
                        //        + " SASymFlags3=\"0x0000\" SASymTextFlags=\"0x003a\" SASymStyle=\"0\" SASymAuxStyle=\"0x0000\" SASymOccurs=\"0x01\" SASymOccOffset=\"0x00\" SASymBGColor=\"0x00\" SASymFGColor=\"0x00\""
                        //        + " SASymPrompt=\"0x00\" SASymFrExArcChar=\"0x00\" SASymToExArcChar=\"0x00\" SASymUncleCount=\"0x00\" SASymStyleFlags=\"0x0003\" SASymSeqNum=\"0\" SASymRotation=\"0\" SASymError1=\"0x00\""
                        //        + " SASymError2=\"0x00\" SASymHideProgeny=\"0\" SASymHidden=\"0\" SASymOtherForm=\"0\" SASymHasDspMode=\"0\" SASymDspMode=\"0x0000\" SASymDspModeExt=\"0x00000000\" SASymCLevelNumber=\"0\""
                        //        + " SASymPenColorOn=\"1\" SASymPenColorRed=\"0\" SASymPenColorGreen=\"130\" SASymPenColorBlue=\"236\" SASymFillColorOn=\"1\" SASymFillColorRed=\"176\" SASymFillColorGreen=\"213\""
                        //        + " SASymFillColorBlue=\"255\" SASymFontColorOn=\"0\" SASymFontColorRed=\"0\" SASymFontColorGreen=\"0\" SASymFontColorBlue=\"0\" SASymLocX=\"" + loc_x + "\" SASymLocY=\"" + loc_y + "\" SASymSizeX=\"" + size_x + "\""
                        //        + " SASymSizeY=\"" + size_y + "\" SASymNameLocX=\"-150\" SASymNameLocY=\"-100\" SASymNameSizeX=\"0\" SASymNameSizeY=\"0\" SASymDescLocX=\"0\" SASymDescLocY=\"0\" SASymDescSizeX=\"0\" SASymDescSizeY=\"0\""
                        //        + " SASymZPPicFile=\"P" + count.ToString("D7") + ".BMP\" SASymZPPicType=\"0x0101\">");

                        //    writer.WriteRaw("<SAPicture SAPictureEncodingMethod=\"Hex\" SAPictureEncodingVersion=\"1.0\" SAOriginalFile=\"P" + count.ToString("D7") + ".BMP\" SAOriginalFileLength=\"152054\" SAPictureData=\"" + value.value + "\"/>"
                        //        + " <SAProperty SAPrpName=\"~C~\" SAPrpValue=\"2\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/><SAProperty SAPrpName=\"~T~\" SAPrpValue=\"11\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/></SASymbol>");
                        //}

                        if (doc_block_views.TryGetValue(view.id, out value))
                        {
                            if (location_dic.TryGetValue(view.id, out location) == true)
                            {
                                loc_x = location.top_left_x;
                                loc_y = location.top_left_y;
                                size_x = (Convert.ToInt32(location.bottom_right_x) - Convert.ToInt32(location.top_left_x)).ToString();
                                size_y = (Convert.ToInt32(location.top_left_y) - Convert.ToInt32(location.bottom_right_y)).ToString();
                            }
                            else
                            {
                                loc_x = "574";
                                loc_y = "203";
                                size_x = "125";
                                size_y = "55";
                            }

                            writer.WriteRaw("<SASymbol SAObjId=\"" + value.id + "\" SAObjName=\"\" SAObjMinorTypeName=\"Doc Block\" SAObjMinorTypeNum=\"4\" SAObjMajorTypeNum=\"2\" SAObjAuditId=\"SAS\" SAObjUpdateDate=\"1/29/2015\" SAObjUpdateTime=\"3:01:32 PM\""
                            + " SAObjFQName=\"&quot;&quot;\" SASymIdDgm=\"" + view.id + "\" SASymArrangement=\"0\" SASymOtherSymbology=\"0\" SASymProperties=\"0x0000\" SASymOrder=\"0\" SASymXPEntity=\"3\" SASymXPLink=\"65535\" SASymXPGroup=\"65535\" SASymXPSibling=\"0\""
                            + " SASymXPSubordinate=\"65535\" SASymPenStyle=\"0x0010\" SASymFontName=\"\" SASymFontHeight=\"0x0000\" SASymFontFlags=\"0x0000\" SASymLineStyle=\"0x0103\" SASymFlags=\"0x0002\" SASymFlags2=\"0x0000\" SASymFlags3=\"0x0000\" SASymTextFlags=\"0x000a\""
                            + " SASymStyle=\"0\" SASymAuxStyle=\"0x0000\" SASymOccurs=\"0x01\" SASymOccOffset=\"0x00\" SASymBGColor=\"0x00\" SASymFGColor=\"0x00\" SASymPrompt=\"0x00\" SASymFrExArcChar=\"0x00\" SASymToExArcChar=\"0x00\" SASymUncleCount=\"0x00\""
                            + " SASymStyleFlags=\"0x0003\" SASymSeqNum=\"0\" SASymRotation=\"0\" SASymError1=\"0x00\" SASymError2=\"0x00\" SASymHideProgeny=\"0\" SASymHidden=\"0\" SASymOtherForm=\"0\" SASymHasDspMode=\"0\" SASymDspMode=\"0x0000\" SASymDspModeExt=\"0x00000000\""
                            + " SASymCLevelNumber=\"0\" SASymPenColorOn=\"1\" SASymPenColorRed=\"0\" SASymPenColorGreen=\"130\" SASymPenColorBlue=\"236\" SASymFillColorOn=\"1\" SASymFillColorRed=\"176\" SASymFillColorGreen=\"213\" SASymFillColorBlue=\"255\" SASymFontColorOn=\"0\""
                            + " SASymFontColorRed=\"0\" SASymFontColorGreen=\"0\" SASymFontColorBlue=\"0\" SASymLocX=\"" + loc_x + "\" SASymLocY=\"" + loc_y + "\" SASymSizeX=\"" + size_x + "\" SASymSizeY=\"" + size_y + "\" SASymNameLocX=\"569\" SASymNameLocY=\"166\" SASymNameSizeX=\"393\" SASymNameSizeY=\"51\""
                            + " SASymDescLocX=\"620\" SASymDescLocY=\"367\" SASymDescSizeX=\"273\" SASymDescSizeY=\"17\" SASymZPDesc=\"" + value.value + "\"><SAProperty SAPrpName=\"~C~\" SAPrpValue=\"2\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                            + "<SAProperty SAPrpName=\"~T~\" SAPrpValue=\"4\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/><SAProperty SAPrpName=\"Description\" SAPrpValue=\"" + value.value + "\" SAPrpEditType=\"1\" SAPrpLength=\"4074\"/></SASymbol>");
                        }

                        writer.WriteRaw(@"</SADiagram>");

                        foreach (Thing thing in thing_list)
                        {
                            if (!SA_Def_elements.Contains(thing.id))
                            {
                                SA_Def_elements.Add(thing.id);
                                thing_GUID = thing_GUIDs[thing.id];

                                minor_type = Find_Definition_Element_SA_Minor_Type(thing.type);

                                writer.WriteRaw("<SADefinition SAObjId=\"" + thing.id + "\" SAObjName=\"" + thing.name + "\" SAObjMinorTypeName=\"" + thing.type + "\" "
                                    + "SAObjMinorTypeNum=\"" + minor_type + "\" SAObjMajorTypeNum=\"3\" SAObjAuditId=\"NEAR\" SAObjUpdateDate=\"" + date + "\" "
                                    + "SAObjUpdateTime=\"" + time + "\" SAObjFQName=\"&quot;" + thing_GUID + "&quot;." + thing.name + "\">"
                                    + "<SAProperty SAPrpName=\"~C~\" SAPrpValue=\"3\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                                    + "<SAProperty SAPrpName=\"~T~\" SAPrpValue=\"" + minor_type + "\" SAPrpEditType=\"0\" SAPrpLength=\"0\"/>"
                                    + "<SAProperty SAPrpName=\"GUID\" SAPrpValue=\"" + thing_GUID + "\" SAPrpEditType=\"1\" SAPrpLength=\"64\"/>"
                                    + "<SAProperty SAPrpName=\"KeyGUID\" SAPrpValue=\"" + thing_GUID + "\" SAPrpEditType=\"1\" SAPrpLength=\"80\"/>"
                                    + "<SAProperty SAPrpName=\"Is Instance\" SAPrpValue=\"F\" SAPrpEditType=\"4\" SAPrpLength=\"1\"/>"
                                    + ((minor_type == "1327") ? "" : "<SAProperty SAPrpName=\"To Line End\" SAPrpValue=\"LineEnd1\" SAPrpEditType=\"1\" SAPrpLength=\"1200\"/>"));

                                //

                                //<SAProperty SAPrpName="Parent Of Capability" SAPrpValue="Definition:&quot;Capability (DM2)&quot;:&quot;99be13e4-03b9-43f1-bf82-0d508bea5cc3&quot;.&quot;(JCA 1.0) Force Support&quot;
                                //    Definition:&quot;Capability (DM2)&quot;:a697273a-8c0e-4f84-b18e-7c6876dd0742.&quot;(JCA 2.0) Battlespace Awareness&quot;
                                //    Definition:&quot;Capability (DM2)&quot;:&quot;3f98f92e-fe73-43e6-b506-7e4e86f861db&quot;.&quot;(JCA 3.0) Force Application&quot;
                                //    Definition:&quot;Capability (DM2)&quot;:cd8cef3b-87a6-402f-9205-70e0794766c8.&quot;(JCA 4.0) Logistics&quot;
                                //    Definition:&quot;Capability (DM2)&quot;:c5376ccf-5b8f-4a10-9d94-ef39ae03b453.&quot;(JCA 5.0) Command and Control&quot;
                                //    Definition:&quot;Capability (DM2)&quot;:&quot;0f6cfd54-7aca-4c75-98b2-c7a785ad9fb6&quot;.&quot;(JCA 6.0) Net-Centric&quot;" SAPrpEditType="14" SAPrpLength="1200" SAPrpEditDefMajorType="Definition" SAPrpEditDefMinorType="Capability (DM2)">
                                //    <SALink SALinkName="&quot;(JCA 1.0) Force Support&quot;" SALinkIdentity="_15647"/>
                                //    <SALink SALinkName="&quot;(JCA 2.0) Battlespace Awareness&quot;" SALinkIdentity="_15639"/>
                                //    <SALink SALinkName="&quot;(JCA 3.0) Force Application&quot;" SALinkIdentity="_15644"/>
                                //    <SALink SALinkName="&quot;(JCA 4.0) Logistics&quot;" SALinkIdentity="_15648"/>
                                //    <SALink SALinkName="&quot;(JCA 5.0) Command and Control&quot;" SALinkIdentity="_15643"/>
                                //    <SALink SALinkName="&quot;(JCA 6.0) Net-Centric&quot;" SALinkIdentity="_15642"/>
                                //</SAProperty>

                                //

                                sorted_results = Get_Tuples_place1(thing, tuples);
                                sorted_results.AddRange(Get_Tuples_place1(thing, tuple_types));
                                sorted_results.AddRange(Get_Tuples_place2(thing, tuples));
                                sorted_results.AddRange(Get_Tuples_place2(thing, tuple_types));
                                //values = new List<Thing>();
                                //if (support_views.TryGetValue(view.id, out values))
                                //    sorted_results.AddRange(Get_Tuples_place1(thing, values));
                                //values = new List<Thing>();
                                //if (needline_views.TryGetValue(view.id, out values))
                                //    sorted_results.AddRange(Get_Tuples_id(thing, values));


                                if (sorted_results.Count() > 0)
                                {
                                    foreach (List<Thing> list in sorted_results)
                                    {
                                        count2 = 0;

                                        foreach (Thing rela in list)
                                        {

                                            if (thing_GUIDs.TryGetValue(rela.place2, out temp_GUID))
                                            {
                                                if (count2 == 0)
                                                {
                                                    temp = "<SAProperty SAPrpName=\"" + list.First().type + "\" SAPrpValue=\"";
                                                    temp3 = "";
                                                    temp2 = "";
                                                    count2++;
                                                }

                                                if (things.TryGetValue(rela.place2, out value))
                                                {
                                                    temp = temp + "Definition:&quot;" + value.value + "&quot;:&quot;" + temp_GUID + ".&quot;" + value.name + "&quot;";
                                                    temp2 = "\" SAPrpEditType=\"14\" SAPrpLength=\"1200\" SAPrpEditDefMajorType=\"Definition\" SAPrpEditDefMinorType=\"" + value.value + "\">";
                                                    temp3 = temp3 + "<SALink SALinkName=\"&quot;" + value.name + "&quot;\" SALinkIdentity=\"" + value.id + "\"/>";
                                                }
                                            }
                                        }

                                        if (count2 > 0)
                                            writer.WriteRaw(temp + temp2 + temp3 + "</SAProperty>");
                                    }
                                }

                                //

                                writer.WriteRaw("<SAProperty SAPrpName=\"Initial Date\" SAPrpValue=\"" + prop_date + "\" SAPrpEditType=\"2\" SAPrpLength=\"10\"/>"
                               + "<SAProperty SAPrpName=\"Initial Time\" SAPrpValue=\"" + prop_time + "\" SAPrpEditType=\"7\" SAPrpLength=\"11\"/>"
                               + "<SAProperty SAPrpName=\"Initial Audit\" SAPrpValue=\"NEAR\" SAPrpEditType=\"1\" SAPrpLength=\"8\"/>"
                               + "<SAProperty SAPrpName=\"Last Change Date\" SAPrpValue=\"" + prop_date + "\" SAPrpEditType=\"2\" SAPrpLength=\"10\"/>"
                               + "<SAProperty SAPrpName=\"Last Change Time\" SAPrpValue=\"" + prop_time + "\" SAPrpEditType=\"7\" SAPrpLength=\"11\"/>"
                               + "<SAProperty SAPrpName=\"Last Change Audit\" SAPrpValue=\"NEAR\" SAPrpEditType=\"1\" SAPrpLength=\"8\"/>"
                               + "</SADefinition>");
                            }
                        }
                        //writer.WriteRaw(@"<MandatoryElements>");

                        //foreach (Thing thing in view.mandatory)
                        //{
                        //    writer.WriteRaw("<" + view.type + "_" + thing.type + " ref=\"id" + thing.id + "\"/>");
                        //}

                        //writer.WriteRaw(@"</MandatoryElements>");
                        //writer.WriteRaw(@"<OptionalElements>");

                        //foreach (Thing thing in view.optional)
                        //{
                        //    writer.WriteRaw("<" + view.type + "_" + thing.type + " ref=\"id" + thing.id + "\"/>");
                        //}

                        //writer.WriteRaw(@"</OptionalElements>");
                        //writer.WriteRaw("</" + view.type + ">");
                        writer.WriteRaw(@"</Class>");
                    }

                    //foreach (Thing thing in things)
                    //    writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id + "\" "
                    //        + (((string)thing.value == "$none$") ? "" : thing.value_type + "=\"" + (string)thing.value + "\"") + ">" + "<ideas:Name exemplarText=\"" + thing.name
                    //        + "\" namingScheme=\"ns1\" id=\"n" + thing.id + "\"/></" + thing.type + ">");

                    //foreach (Thing thing in tuple_types)
                    //    writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id
                    //    + "\" place1Type=\"id" + thing.place1 + "\" place2Type=\"id" + thing.place2 + "\"/>");

                    //foreach (Thing thing in tuples)
                    //    writer.WriteRaw("<" + thing.type + " ideas:FoundationCategory=\"" + thing.foundation + "\" id=\"id" + thing.id
                    //    + "\" tuplePlace1=\"id" + thing.place1 + "\" tuplePlace2=\"id" + thing.place2 + "\"/>");

                    //writer.WriteRaw(@"</IdeasData>");

                    //writer.WriteRaw(@"<IdeasViews frameworkVersion=""DM2.02_Chg_1"" framework=""DoDAF"">");

                    writer.WriteRaw(@"</Classes>");

                    writer.Flush();
                }

                output = sw.ToString();
                errors = string.Join("", errors_list.Distinct().ToArray());

                if (errors.Count() > 0)
                    test = false;

                return test;
            }
        }
    }
}
