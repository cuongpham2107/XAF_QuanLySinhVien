import{DxUIHandlersBridgeTagName as t}from"./dx-ui-handlers-bridge-4076ae57.js";import{I as e}from"./input-group-container-5f00a731.js";import{m as s}from"./masks-611d9850.js";import{s as n}from"./lit-element-b0a6fcba.js";import"./dx-ui-element-de378e9d.js";import"./logicaltreehelper-15991dcb.js";import"./layouthelper-4b19d191.js";import"./rect-7fc5c2ef.js";import"./point-9c6ab88a.js";import"./lit-element-base-af247167.js";import"./data-qa-utils-8be7c726.js";import"./browser-a3d50e79.js";import"./key-a83dbe57.js";import"./dom-95153cd1.js";import"./_tslib-158249d5.js";import"./disposable-d2c2d283.js";import"./dom-utils-2919d18e.js";var i;!function(t){t[t.Focus=1]="Focus",t[t.FocusOut=2]="FocusOut",t[t.Input=8]="Input",t[t.Paste=16]="Paste",t[t.Wheel=32]="Wheel"}(i||(i={}));class u extends e{constructor(){super(...arguments),this.highightObserver=new MutationObserver(this.highlightInputValue.bind(this)),this.proccessedEvents=0,this.boundOnInputFocusHandler=this.onInputFocus.bind(this),this.boundOnInputFocusOutHandler=this.onInputFocusOut.bind(this)}disconnectedCallback(){var t,e;null===(t=this.inputElement)||void 0===t||t.removeEventListener("focus",this.boundOnInputFocusHandler),null===(e=this.inputElement)||void 0===e||e.removeEventListener("focusout",this.boundOnInputFocusOutHandler),this.highightObserver.disconnect(),this.inputElement&&s.dispose(this.inputElement),super.disconnectedCallback()}onSlotChanged(e){super.onSlotChanged(e),this.uiHandlersBridge=this.querySelector(t),this.inputElement=this.getInputElement(),this.inputElement&&this.bitsHasEvent(this.proccessedEvents,i.Focus)&&this.inputElement.addEventListener("focus",this.boundOnInputFocusHandler),this.inputElement&&this.bitsHasEvent(this.proccessedEvents,i.FocusOut)&&this.inputElement.addEventListener("focusout",this.boundOnInputFocusOutHandler)}onInputFocus(t){var e;if(!this.inputElement)return;const s=0===this.inputElement.selectionStart&&this.inputElement.selectionEnd===(this.inputElement.value?this.inputElement.value.length:0)&&document.activeElement===this.inputElement;this.highightObserver.observe(this.inputElement,{attributeFilter:["data-need-highlight"]}),null===(e=this.uiHandlersBridge)||void 0===e||e.send("onFocusStateChanged",{focus:!0,needHighlight:s})}onInputFocusOut(t){var e,s;null===(e=this.uiHandlersBridge)||void 0===e||e.send("onFocusStateChanged",{focus:!1,text:null===(s=this.inputElement)||void 0===s?void 0:s.value})}registerButton(t){}unregisterButton(t){}highlightInputValue(){this.inputElement&&document.activeElement===this.inputElement&&(this.inputElement.select(),this.inputElement.removeAttribute("data-need-highlight"),this.highightObserver.disconnect())}static get baseObservedAttributes(){return["proccessed-events"]}attributeChangedCallback(t,e,s){if("proccessed-events"===t)this.onProccessedEventsChanged(s);this.attributeChangedCallbackInternal(t,e,s)}onProccessedEventsChanged(t){const e=parseInt(t),s=e^this.proccessedEvents,n=s&e,i=s&this.proccessedEvents;this.proccessedEvents=e,this.subscribeNewEvents(n),this.unsubscribeOldEvents(i)}subscribeNewEvents(t){t&&this.inputElement&&(this.bitsHasEvent(t,i.Focus)&&this.inputElement.addEventListener("focus",this.boundOnInputFocusHandler),this.bitsHasEvent(t,i.FocusOut)&&this.inputElement.addEventListener("focusout",this.boundOnInputFocusOutHandler))}unsubscribeOldEvents(t){t&&this.inputElement&&(this.bitsHasEvent(t,i.Focus)&&this.inputElement.removeEventListener("focus",this.boundOnInputFocusHandler),this.bitsHasEvent(t,i.FocusOut)&&this.inputElement.removeEventListener("focusout",this.boundOnInputFocusOutHandler))}bitsHasEvent(t,e){return(t&e)>0}attributeChangedCallbackInternal(t,e,s){}}u.shadowRootOptions={...n.shadowRootOptions,delegatesFocus:!0};customElements.define("dxbl-input-editor",class extends u{static get observedAttributes(){return this.baseObservedAttributes}});const o={loadModule:function(){}};export{u as DxInputEditorBase,i as EditorsProccessedEvents,o as default};