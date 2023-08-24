using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.Diagram;
using Syncfusion.Blazor.Diagram.SymbolPalette;
using System.Xml.Linq;

namespace BPMNEditor
{
    public partial class DiagramSymbolpalette
    {
        /// <summary>
        /// This method used to render the nodes or connectors in the Symbol Palette
        /// </summary>
        private void InitializePalettes()
        {
            BPMNShapeSymbols = new DiagramObjectCollection<NodeBase>();
            Node node1 = new Node()
            {
                ID = "Task",
                Width = 35,
                Height = 30,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.None }
            };
            BPMNShapeSymbols.Add(node1);
            Node node2 = new Node()
            {
                ID = "Gateway",
                Width = 96,
                Height = 72,
                Shape = new BpmnGateway() { GatewayType = BpmnGatewayType.None }
            };
            BPMNShapeSymbols.Add(node2);
            Node node3 = new Node()
            {
                ID = "IntermediateEvent",
                Width = 30,
                Height = 30,
                Shape = new BpmnEvent() { EventType = BpmnEventType.Intermediate, Trigger = BpmnEventTrigger.None },
                Tooltip = new DiagramTooltip()
                {
                    Content = "Intermediate Event"
                },
                Constraints = NodeConstraints.Default | NodeConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(node3);
            Node node4 = new Node()
            {
                ID = "EndEvent",
                Width = 30,
                Height = 30,
                Shape = new BpmnEvent() { EventType = BpmnEventType.End, Trigger = BpmnEventTrigger.None },
                Tooltip = new DiagramTooltip()
                {
                    Content = "End Event"
                },
                Constraints = NodeConstraints.Default | NodeConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(node4);
            Node node5 = new Node()
            {
                ID = "StartEvent",
                Width = 30,
                Height = 30,
                Shape = new BpmnEvent() { EventType = BpmnEventType.Start, Trigger = BpmnEventTrigger.None },
                Tooltip = new DiagramTooltip()
                {
                    Content = "Start Event"
                },
                Constraints = NodeConstraints.Default | NodeConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(node5);
            Node node6 = new Node()
            {
                ID = "CollapsedSub-Process",
                Width = 96,
                Height = 72,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.CollapsedSubProcess },
                Tooltip = new DiagramTooltip()
                {
                    Content = "Collapsed Sub-Process"
                },
                Constraints = NodeConstraints.Default | NodeConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(node6);
            Node node7 = new Node()
            {
                ID = "ExpandedSub-Process",
                Width = 96,
                Height = 72,
                Shape = new BpmnExpandedSubProcess()
                {
                    SubProcessType = BpmnSubProcessType.Transaction
                },
                Tooltip = new DiagramTooltip()
                {
                    Content = "Expanded Sub-Process"
                },
                Constraints = NodeConstraints.Default | NodeConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(node7);
            Node node8 = new Node()
            {
                ID = "TextAnnotation",
                Width = 96,
                Height = 72,
                Shape = new BpmnTextAnnotation(),
                Tooltip = new DiagramTooltip()
                {
                    Content = "Text Annotation"
                },
                Constraints = NodeConstraints.Default | NodeConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(node8);
            Connector connector1 = new Connector()
            {
                ID = "SequenceFlow",
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 60, Y = 60 },
                Type = ConnectorSegmentType.Straight,
                Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow },
                Tooltip = new DiagramTooltip()
                {
                    Content = "Sequence Flow"
                },
                Constraints = ConnectorConstraints.Default | ConnectorConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(connector1);
            Connector connector2 = new Connector() { ID = "Association", SourcePoint = new DiagramPoint() { X = 0, Y = 0 }, TargetPoint = new DiagramPoint() { X = 60, Y = 60 }, Type = ConnectorSegmentType.Straight, Shape = new BpmnFlow() { Flow = BpmnFlowType.AssociationFlow }, };
            BPMNShapeSymbols.Add(connector2);
            Connector connector3 = new Connector()
            {
                ID = "MessageFlow",
                SourcePoint = new DiagramPoint() { X = 0, Y = 0 },
                TargetPoint = new DiagramPoint() { X = 60, Y = 60 },
                Type = ConnectorSegmentType.Straight,
                TargetDecorator = new DecoratorSettings() { Style = new ShapeStyle() { Fill = "white" } },              
                Style = new ShapeStyle() { StrokeDashArray = "5 5" },
                Tooltip = new DiagramTooltip()
                {
                    Content = "Message Flow"
                },
                Constraints = ConnectorConstraints.Default | ConnectorConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(connector3);

            Node node9 = new Node()
            {
                ID = "Message",
                Width = 72,
                Height = 48,
                Shape = new BpmnMessage()
            };
            BPMNShapeSymbols.Add(node9);

            Node node10 = new Node()
            {
                ID = "DataObject",
                Width = 48,
                Height = 62,
                Shape = new BpmnDataObject() { IsCollectiveData = false, DataObjectType = BpmnDataObjectType.None },
                Tooltip = new DiagramTooltip()
                {
                    Content = "Data Object"
                },
                Constraints = NodeConstraints.Default | NodeConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(node10);
            Node node11 = new Node()
            {
                ID = "DataStore",
                Width = 96,
                Height = 76,
                Shape = new BpmnDataStore(),
                Tooltip = new DiagramTooltip()
                {
                    Content = "Data Store"
                },
                Constraints = NodeConstraints.Default | NodeConstraints.Tooltip
            };
            BPMNShapeSymbols.Add(node11);
           

        }        
     
    }
}
