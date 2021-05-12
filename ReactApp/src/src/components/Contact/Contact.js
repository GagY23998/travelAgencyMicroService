import "./Contact.css";
const Contact = (props)=>{

    const resetFields = ()=>{
        document.querySelectorAll(".formInput").forEach(el=>{
            el.value ="";
        });
        document.querySelector(".formTextArea").value="";
    }

    return (<div className="formContainer">
        <div className="formHeader"><h3>Contact</h3></div>
        <form className="contactForm">
            <div className="formSection">
                <label className="formLabel">Name</label>
                <input className="formInput" type="text"/>
            </div>
            <div className="formSection">
                <label className="formLabel">Address</label>
                <input className="formInput" type="text"/>
            </div>
            <div className="formSection">
                <label className="formLabel">Question</label>
                <textarea className="formTextArea" rows="10">
                    
                </textarea>
            </div>
            <div className="buttonSection">
                <button type="button" className="btn__Submit">Submit</button>
                <button type="button" className="btn__Reset" onClick={resetFields}>Reset</button>
            </div>
        </form>
    </div>);
}
export default Contact;