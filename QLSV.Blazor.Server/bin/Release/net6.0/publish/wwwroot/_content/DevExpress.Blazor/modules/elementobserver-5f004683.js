class e{constructor(e,t){this.target=null,this.targetMutationObserver=new MutationObserver((e=>this.handleTargetMutations.bind(this))),this.observedElement=null,this.selector=e,this.callback=t}get hasObservedElement(){return null!==this.observedElement}observe(e=null){this.disconnect(),this.target=e;const t=null!=e?e:document;this.observedElement=t.querySelector(this.selector),this.observedElement&&this.raiseElementChanged(null,this.observedElement),this.targetMutationObserver.observe(t,{subtree:!0,childList:!0})}disconnect(){this.targetMutationObserver.disconnect()}raiseElementChanged(e,t){this.callback({oldElement:e,element:t},this)}handleTargetMutations(e,t){this.hasObservedElement?this.processRemovedNodes(e):this.processAddedNodes(e)}processRemovedNodes(e){this.processRemovedNodesInternal(e)&&(this.raiseElementChanged(this.observedElement,null),this.observedElement=null)}processRemovedNodesInternal(e){return e.forEach((e=>{e.removedNodes.forEach((e=>{if(this.observedElement===e)return!0}))})),!1}processAddedNodes(e){const[t,s]=this.processAddedNodesInternal(e);t&&(this.raiseElementChanged(this.observedElement,s),this.observedElement=s)}processAddedNodesInternal(e){var t;const s=(null!==(t=this.target)&&void 0!==t?t:document).querySelector(this.selector);return[null!==s,s]}}export{e as E};