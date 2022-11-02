import{ThumbDragStartedEvent as t,ThumbDragDeltaEvent as e,ThumbDragCompletedEvent as a}from"./thumb-b78dcc42.js";import{E as s}from"./eventhelper-8570b930.js";import{D as i}from"./data-qa-utils-8be7c726.js";import{L as r,D as d}from"./layouthelper-4b19d191.js";import{R as l}from"./rafaction-bba7928b.js";import{T as n}from"./transformhelper-ebad0156.js";import"./point-9c6ab88a.js";import"./rect-7fc5c2ef.js";class o extends HTMLElement{constructor(){super(),this.dragX=0,this.dragY=0,this.leftField=0,this.topField=0,this.rafAction=new l,this.dragStartedHandler=this.dragStarted.bind(this),this.dragDeltaHandler=this.dragDelta.bind(this),this.dragCompletedHandler=this.dragCompleted.bind(this);this.attachShadow({mode:"closed"}).innerHTML="\n            <style>\n              :host {\n                  position: absolute;\n                  display: block;\n              }\n            </style>\n            <slot/>"}get left(){return this.leftField}set left(t){this.leftField=t}get top(){return this.topField}set top(t){this.topField=t}connectedCallback(){i.setLoaded(this),this.addEventListener(t.eventName,this.dragStartedHandler),this.addEventListener(e.eventName,this.dragDeltaHandler),this.addEventListener(a.eventName,this.dragCompletedHandler)}disconnectedCallback(){i.removeLoaded(this)}dragStarted(t){s.markHandled(t);const e=r.findParent(this,(t=>d.isAbsolutePositioning(t))),a=r.getRelativeElementRect(this,e);this.left=a.x,this.top=a.y,this.style.transform=n.translate(this.left,this.top)}dragDelta(t){s.markHandled(t),this.left+=t.detail.deltaX,this.top+=t.detail.deltaY,this.rafAction.execute((()=>this.style.transform=n.translate(this.left,this.top)))}dragCompleted(t){s.markHandled(t),this.rafAction.cancel(),this.style.transform=n.translate(this.left,this.top)}}customElements.define("dxbl-draggable",o);const h={init:function(){},DxDraggable:o,dxDraggableTagName:"dxbl-draggable"};export{h as default};