using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;
using Syncfusion.Blazor.Diagram;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

using BPMNEditor.Shared;

namespace BPMNEditor
{
    public partial class DiagramMainContent
    {

        /// <summary>
        /// Sets content for Barcode generator display text element including HTML support and its customizations.
        /// </summary>        
        FitOptions options = new FitOptions() { Mode = FitMode.Both, Region = DiagramRegion.Content };
        public bool IsDiagramCreated = false;
        public bool IsPasteOptionEnabled { get; set; } = false;

        public SfDiagramComponent Diagram { get; set; }

        public DiagramMain Parent { get; set; }
        //  public DiagramMain Parent { get; set; } = MainLayout.DiagramMain;

        public DiagramMainContent()
        {
            //this.Diagram = new SfDiagramComponent();
            //Parent! = null;
        }
        public DiagramMainContent(DiagramMain parent)
        {
            Parent = parent;
            this.Diagram = new SfDiagramComponent();

        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync().ConfigureAwait(true);
            Parent?.InitializeDiagraMainContent(this);

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Parent?.InitializeDiagraMainContent(this);

        }


        //}
        /// <summary>
        /// This method will be called when diagram is created
        /// </summary>  
        private void OnCreated()
        {
            IsDiagramCreated = true;
            Diagram.FitToPage(options);
            Parent.Toolbar.ZoomItemVisibility = true;
            Parent.Toolbar.HideItemVisibility = true;
            Parent.Toolbar.StateChanged();
        }
        /// <summary>
        /// Initializes the diagram model with default BPMN diagram
        /// </summary> 
        private void InitDiagramModel()
        {
            Node node1 = new Node()
            {
                ID = "node1",
                OffsetX = 100,
                OffsetY = 300,
                Width = 50,
                Height = 50,
                Shape = new BpmnEvent() { EventType = BpmnEventType.Start, Trigger = BpmnEventTrigger.None },
                Style = new ShapeStyle() { Fill = "White" },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
            };
            nodes.Add(node1);

            Node node2 = new Node()
            {
                ID = "node2",
                Width = 120,
                Height = 80,
                OffsetX = 250,
                OffsetY = 300,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.Receive },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node1Annotation1",
                                Content = "Receive Book Lending Request",
                                Visibility = true,
                                Style = new TextStyle(){ FontSize = 12, TextAlign = TextAlign.Center,
                                TextWrapping = TextWrap.WrapWithOverflow },
                            },
                }
            };
            nodes.Add(node2);

            Node node3 = new Node()
            {
                ID = "node3",
                Width = 120,
                Height = 80,
                OffsetX = 450,
                OffsetY = 300,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.Service },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node3Annotation1",
                                Content = "Get the Book Status",
                                Visibility = true,
                                Style = new TextStyle(){ FontSize = 12, TextAlign = TextAlign.Center,
                                TextWrapping = TextWrap.WrapWithOverflow },
                            },
                },
            };
            nodes.Add(node3);

            Node node4 = new Node()
            {
                ID = "node4",
                OffsetX = 600,
                OffsetY = 300,
                Width = 90,
                Height = 80,
                Shape = new BpmnGateway() { GatewayType = BpmnGatewayType.None },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 }
            };
            nodes.Add(node4);

            Node node5 = new Node()
            {
                ID = "node5",
                Width = 120,
                Height = 80,
                OffsetX = 800,
                OffsetY = 300,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.Send },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node5Annotation1",
                                Content = "On Load Reply",
                                Visibility = true,
                                Style = new TextStyle(){ FontSize = 12, TextAlign = TextAlign.Center,
                                TextWrapping = TextWrap.WrapWithOverflow },
                            },
                }
            };
            nodes.Add(node5);

            Node node6 = new Node()
            {
                ID = "node6",
                Width = 90,
                Height = 80,
                OffsetX = 950,
                OffsetY = 300,
                Shape = new BpmnGateway() { GatewayType = BpmnGatewayType.EventBased },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 }

            };
            nodes.Add(node6);

            Node node7 = new Node()
            {
                ID = "node7",
                Width = 50,
                Height = 50,
                OffsetX = 1100,
                OffsetY = 200,
                Shape = new BpmnEvent() { EventType = BpmnEventType.Intermediate, Trigger = BpmnEventTrigger.Message },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node7Annotation1",
                                Content = "Hold Book",
                                Visibility = true,
                                Offset = new DiagramPoint (){ X = 0.5, Y = 1.25 },
                                Style = new TextStyle(){ FontSize = 12},
                                Width = 100
                            },
                }
            };
            nodes.Add(node7);

            Node node8 = new Node()
            {
                ID = "node8",
                Width = 50,
                Height = 50,
                OffsetX = 1100,
                OffsetY = 300,
                Shape = new BpmnEvent() { EventType = BpmnEventType.Intermediate, Trigger = BpmnEventTrigger.Message },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node8Annotation1",
                                Content = "Decline Hold",
                                Visibility = true,
                                Offset = new DiagramPoint (){ X = 0.5, Y = 1.25 },
                                Style = new TextStyle(){ FontSize = 12},
                                Width = 100
                            },
                }

            };
            nodes.Add(node8);

            Node node9 = new Node()
            {
                ID = "node9",
                Width = 40,
                Height = 40,
                OffsetX = 1100,
                OffsetY = 400,
                Shape = new BpmnEvent() { EventType = BpmnEventType.Intermediate, Trigger = BpmnEventTrigger.Message },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node9Annotation1",
                                Content = "One Week",
                                Visibility = true,
                                Offset = new DiagramPoint (){ X = 0.5, Y = 1.25 },
                                Style = new TextStyle(){ FontSize = 12},
                                Width = 100
                            },
                }

            };
            nodes.Add(node9);

            Node node10 = new Node()
            {
                ID = "node10",
                Width = 120,
                Height = 80,
                OffsetX = 1250,
                OffsetY = 200,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.Service },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node10Annotation1",
                                Content = "Request Hold",
                                Visibility = true,
                                Style = new TextStyle(){ FontSize = 12, TextAlign = TextAlign.Center,
                                TextWrapping = TextWrap.WrapWithOverflow },
                            },
                }
            };
            nodes.Add(node10);

            Node node11 = new Node()
            {
                ID = "node11",
                Width = 120,
                Height = 80,
                OffsetX = 1450,
                OffsetY = 200,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.Receive },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node11Annotation1",
                                Content = "Hold Reply",
                                Visibility = true,
                                Style = new TextStyle(){ FontSize = 12, TextAlign = TextAlign.Center,
                                TextWrapping = TextWrap.WrapWithOverflow },
                            },
                 }
            };
            nodes.Add(node11);

            Node node12 = new Node()
            {
                ID = "node12",
                Width = 50,
                Height = 50,
                OffsetX = 940,
                OffsetY = 100,
                Shape = new BpmnEvent() { EventType = BpmnEventType.Intermediate, Trigger = BpmnEventTrigger.Message },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node12Annotation1",
                                Content = "Two Weeks",
                                Visibility = true,
                                Offset = new DiagramPoint (){ X = 0.5, Y = 1.25 },
                                Style = new TextStyle(){ FontSize = 12},
                                Width = 100,
                            },
                }

            };
            nodes.Add(node12);

            Node node13 = new Node()
            {
                ID = "node13",
                Width = 120,
                Height = 80,
                OffsetX = 800,
                OffsetY = 540,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.User },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node13Annotation1",
                                Content = "Checkout the Book",
                                Visibility = true,
                                Style = new TextStyle(){ FontSize = 12, TextAlign = TextAlign.Center,
                                TextWrapping = TextWrap.WrapWithOverflow },
                            },
                }
            };
            nodes.Add(node13);

            Node node14 = new Node()
            {
                ID = "node14",
                Width = 120,
                Height = 80,
                OffsetX = 1050,
                OffsetY = 540,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.Receive },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node14Annotation1",
                                Content = "Checkout reply",
                                Visibility = true,
                                Style = new TextStyle(){ FontSize = 12, TextAlign = TextAlign.Center,
                                TextWrapping = TextWrap.WrapWithOverflow },
                            },
                }
            };
            nodes.Add(node14);

            Node node15 = new Node()
            {
                ID = "node15",
                Width = 120,
                Height = 80,
                OffsetX = 1250,
                OffsetY = 300,
                Shape = new BpmnActivity() { ActivityType = BpmnActivityType.Task, TaskType = BpmnTaskType.Receive },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 },
                Annotations = new DiagramObjectCollection<ShapeAnnotation>()
                {
                            new ShapeAnnotation()
                            {
                                ID = "Node15Annotation1",
                                Content = "Cancel Request",
                                Visibility = true,
                                Style = new TextStyle(){ FontSize = 12, TextAlign = TextAlign.Center,
                                TextWrapping = TextWrap.WrapWithOverflow },
                            },
                }
            };
            nodes.Add(node15);

            Node node16 = new Node()
            {
                ID = "node16",
                OffsetX = 1450,
                OffsetY = 300,
                Width = 50,
                Height = 50,
                Shape = new BpmnEvent() { EventType = BpmnEventType.End, Trigger = BpmnEventTrigger.None },
                Ports = new DiagramObjectCollection<PointPort>() {
                     new PointPort() { ID="port1", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port2", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 0}, Height = 20, Width = 20 },
                     new PointPort() { ID="port3", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 1, Y = 0.5}, Height = 20, Width = 20 },
                     new PointPort() { ID="port4", Visibility = PortVisibility.Hidden, Offset = new DiagramPoint() { X = 0.5, Y = 1}, Height = 20, Width = 20 }
                 }
            };
            nodes.Add(node16);
            Connector connector1 = new Connector() { ID = "connector1", SourceID = "node1", TargetID = "node2", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector1);
            Connector connector2 = new Connector() { ID = "connector2", SourceID = "node2", TargetID = "node3", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector2);
            Connector connector3 = new Connector() { ID = "connector3", SourceID = "node3", TargetID = "node4", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector3);
            Connector connector4 = new Connector() { ID = "connector4", SourceID = "node4", TargetID = "node5", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow }, Annotations = new DiagramObjectCollection<PathAnnotation>() { new PathAnnotation() { Content = "Book is on Loan", Alignment = AnnotationAlignment.Center, Style = new TextStyle() { Fill = "White" }, Width = 60 } } };
            connectors.Add(connector4);
            Connector connector5 = new Connector() { ID = "connector5", SourceID = "node5", TargetID = "node6", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector5);
            Connector connector6 = new Connector() { ID = "connector6", SourceID = "node6", TargetID = "node7", SourcePortID = "port2", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector6);
            Connector connector7 = new Connector() { ID = "connector7", SourceID = "node6", TargetID = "node8", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector7);
            Connector connector8 = new Connector() { ID = "connector8", SourceID = "node6", TargetID = "node9", SourcePortID = "port4", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector8);
            Connector connector9 = new Connector() { ID = "connector9", SourceID = "node7", TargetID = "node10", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector9);
            Connector connector10 = new Connector() { ID = "connector10", SourceID = "node10", TargetID = "node11", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector10);
            Connector connector11 = new Connector() { ID = "connector11", SourceID = "node11", TargetID = "node12", SourcePortID = "port2", TargetPortID = "port3", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector11);
            Connector connector12 = new Connector() { ID = "connector12", SourceID = "node12", TargetID = "node4", SourcePortID = "port1", TargetPortID = "port2", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector12);
            Connector connector13 = new Connector() { ID = "connector13", SourceID = "node4", TargetID = "node13", SourcePortID = "port4", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow }, Annotations = new DiagramObjectCollection<PathAnnotation>() { new PathAnnotation() { Content = "Book is Available", Alignment = AnnotationAlignment.Center, Style = new TextStyle() { Fill = "White" }, Width = 60 } } };
            connectors.Add(connector13);
            Connector connector14 = new Connector() { ID = "connector14", SourceID = "node13", TargetID = "node14", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector14);
            Connector connector15 = new Connector() { ID = "connector15", SourceID = "node8", TargetID = "node15", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector15);
            Connector connector16 = new Connector() { ID = "connector16", SourceID = "node15", TargetID = "node16", SourcePortID = "port3", TargetPortID = "port1", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector16);
            Connector connector17 = new Connector() { ID = "connector17", SourceID = "node14", TargetID = "node16", SourcePortID = "port3", TargetPortID = "port4", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector17);
            Connector connector18 = new Connector() { ID = "connector18", SourceID = "node9", TargetID = "node15", SourcePortID = "port3", TargetPortID = "port4", Type = ConnectorSegmentType.Orthogonal, Shape = new BpmnFlow() { Flow = BpmnFlowType.SequenceFlow } };
            connectors.Add(connector18);
        }


    }
}
