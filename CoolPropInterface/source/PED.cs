/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


public class PED : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal PED(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PED obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~PED() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          CoolPropPINVOKE.delete_PED(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public bool TypeI {
    set {
      CoolPropPINVOKE.PED_TypeI_set(swigCPtr, value);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      bool ret = CoolPropPINVOKE.PED_TypeI_get(swigCPtr);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public bool built {
    set {
      CoolPropPINVOKE.PED_built_set(swigCPtr, value);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      bool ret = CoolPropPINVOKE.PED_built_get(swigCPtr);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public uint iTsat_max {
    set {
      CoolPropPINVOKE.PED_iTsat_max_set(swigCPtr, value);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      uint ret = CoolPropPINVOKE.PED_iTsat_max_get(swigCPtr);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public uint ipsat_max {
    set {
      CoolPropPINVOKE.PED_ipsat_max_set(swigCPtr, value);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      uint ret = CoolPropPINVOKE.PED_ipsat_max_get(swigCPtr);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public uint icrit {
    set {
      CoolPropPINVOKE.PED_icrit_set(swigCPtr, value);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      uint ret = CoolPropPINVOKE.PED_icrit_get(swigCPtr);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t K {
    set {
      CoolPropPINVOKE.PED_K_set(swigCPtr, SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_K_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t lnK {
    set {
      CoolPropPINVOKE.PED_lnK_set(swigCPtr, SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_lnK_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t x {
    set {
      CoolPropPINVOKE.PED_x_set(swigCPtr, SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_x_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t y {
    set {
      CoolPropPINVOKE.PED_y_set(swigCPtr, SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_y_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_std__vectorT_CoolPropDbl_t_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t T {
    set {
      CoolPropPINVOKE.PED_T_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_T_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t p {
    set {
      CoolPropPINVOKE.PED_p_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_p_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t lnT {
    set {
      CoolPropPINVOKE.PED_lnT_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_lnT_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t lnp {
    set {
      CoolPropPINVOKE.PED_lnp_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_lnp_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t rhomolar_liq {
    set {
      CoolPropPINVOKE.PED_rhomolar_liq_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_rhomolar_liq_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t rhomolar_vap {
    set {
      CoolPropPINVOKE.PED_rhomolar_vap_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_rhomolar_vap_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t lnrhomolar_liq {
    set {
      CoolPropPINVOKE.PED_lnrhomolar_liq_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_lnrhomolar_liq_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t lnrhomolar_vap {
    set {
      CoolPropPINVOKE.PED_lnrhomolar_vap_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_lnrhomolar_vap_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t hmolar_liq {
    set {
      CoolPropPINVOKE.PED_hmolar_liq_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_hmolar_liq_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t hmolar_vap {
    set {
      CoolPropPINVOKE.PED_hmolar_vap_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_hmolar_vap_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t smolar_liq {
    set {
      CoolPropPINVOKE.PED_smolar_liq_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_smolar_liq_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t smolar_vap {
    set {
      CoolPropPINVOKE.PED_smolar_vap_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_smolar_vap_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_std__vectorT_CoolPropDbl_t Q {
    set {
      CoolPropPINVOKE.PED_Q_set(swigCPtr, SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(value));
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = CoolPropPINVOKE.PED_Q_get(swigCPtr);
      SWIGTYPE_p_std__vectorT_CoolPropDbl_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_std__vectorT_CoolPropDbl_t(cPtr, false);
      if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public PED() : this(CoolPropPINVOKE.new_PED(), true) {
    if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
  }

  public void resize(uint N) {
    CoolPropPINVOKE.PED_resize(swigCPtr, N);
    if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
  }

  public void clear() {
    CoolPropPINVOKE.PED_clear(swigCPtr);
    if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
  }

  public void insert_variables(SWIGTYPE_p_CoolPropDbl T, SWIGTYPE_p_CoolPropDbl p, SWIGTYPE_p_CoolPropDbl rhomolar_liq, SWIGTYPE_p_CoolPropDbl rhomolar_vap, SWIGTYPE_p_CoolPropDbl hmolar_liq, SWIGTYPE_p_CoolPropDbl hmolar_vap, SWIGTYPE_p_CoolPropDbl smolar_liq, SWIGTYPE_p_CoolPropDbl smolar_vap, SWIGTYPE_p_std__vectorT_CoolPropDbl_t x, SWIGTYPE_p_std__vectorT_CoolPropDbl_t y, uint i) {
    CoolPropPINVOKE.PED_insert_variables(swigCPtr, SWIGTYPE_p_CoolPropDbl.getCPtr(T), SWIGTYPE_p_CoolPropDbl.getCPtr(p), SWIGTYPE_p_CoolPropDbl.getCPtr(rhomolar_liq), SWIGTYPE_p_CoolPropDbl.getCPtr(rhomolar_vap), SWIGTYPE_p_CoolPropDbl.getCPtr(hmolar_liq), SWIGTYPE_p_CoolPropDbl.getCPtr(hmolar_vap), SWIGTYPE_p_CoolPropDbl.getCPtr(smolar_liq), SWIGTYPE_p_CoolPropDbl.getCPtr(smolar_vap), SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(x), SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(y), i);
    if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
  }

  public void store_variables(SWIGTYPE_p_CoolPropDbl T, SWIGTYPE_p_CoolPropDbl p, SWIGTYPE_p_CoolPropDbl rhomolar_liq, SWIGTYPE_p_CoolPropDbl rhomolar_vap, SWIGTYPE_p_CoolPropDbl hmolar_liq, SWIGTYPE_p_CoolPropDbl hmolar_vap, SWIGTYPE_p_CoolPropDbl smolar_liq, SWIGTYPE_p_CoolPropDbl smolar_vap, SWIGTYPE_p_std__vectorT_CoolPropDbl_t x, SWIGTYPE_p_std__vectorT_CoolPropDbl_t y) {
    CoolPropPINVOKE.PED_store_variables(swigCPtr, SWIGTYPE_p_CoolPropDbl.getCPtr(T), SWIGTYPE_p_CoolPropDbl.getCPtr(p), SWIGTYPE_p_CoolPropDbl.getCPtr(rhomolar_liq), SWIGTYPE_p_CoolPropDbl.getCPtr(rhomolar_vap), SWIGTYPE_p_CoolPropDbl.getCPtr(hmolar_liq), SWIGTYPE_p_CoolPropDbl.getCPtr(hmolar_vap), SWIGTYPE_p_CoolPropDbl.getCPtr(smolar_liq), SWIGTYPE_p_CoolPropDbl.getCPtr(smolar_vap), SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(x), SWIGTYPE_p_std__vectorT_CoolPropDbl_t.getCPtr(y));
    if (CoolPropPINVOKE.SWIGPendingException.Pending) throw CoolPropPINVOKE.SWIGPendingException.Retrieve();
  }

}
