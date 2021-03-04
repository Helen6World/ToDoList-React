import React, {useState, useEffect} from "react";
import useForm from "./useForm";
import { connect } from "react-redux";
import * as actions from "../actions/thingToDo";
import { useToasts } from "react-toast-notifications";

const initialFieldValues = {
    content:'',
    isDone:''
}

const ThingToDoForm = ({...props}) => {
    const {addToast} = useToasts()
    const validate=(fieldValues=values)=> {
        let temp = {...errors}
        temp.content = (/^$/).test(values.content)?"This field cannot be empty":"";
        setErrors({
            ...temp
        })
        return Object.values(temp).every(x=>x=="")
    }
    
    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange,
        resetForm
    } = useForm(initialFieldValues, validate, props.setCurrentId)

    const handleSubmit = e => {
        e.preventDefault();
        const onSuccess=()=>{
            resetForm()
            addToast("Submitted successfully", { appearance: 'info' })
        }
        if(!validate()) {
           window.alert('Please enter correct data');
        }
        else{
            if (props.currentId==0) {
                props.createThingToDo(values, onSuccess)
            }
            else {
                props.updateThingToDo(props.currentId,values,onSuccess)
            }
        }
    }

    useEffect(() => {
        if(props.currentId != 0)
            setValues({
                ...props.thingToDoList.find(x => x.id == props.currentId)
            })
        setErrors({})
    }, [props.currentId])

    return (
        <div>
            <form action="" onSubmit={handleSubmit}>
                <p>Create a new task</p>
                <label htmlFor="contentInput">Content:</label>
                <input type="text" id="contentInput" name="content" value={values.content} onChange={handleInputChange}/>
                <br/>
                    <div>
                        Finished:
                    <label>
                       Yes
                       <input
                           type="radio"
                           name="isDone"
                            value="true"
                            checked={values.isDone === "true"}
                            onChange={handleInputChange}
                       />
                           No
                       <input
                           type="radio"
                           name="isDone"
                           value="false"
                           checked={values.isDone === "false"}
                           onChange={handleInputChange}
                       />
                    </label>
                </div>
                <input type="submit" value="Send"/>
                <input type="button" value="Reset" onClick={resetForm}/>
            </form>
        </div>
    );
}

const mapStateToProps = state => ({
    thingToDoList: state.thingToDo.list
})
const mapActionToProps = {
    createThingToDo: actions.create,
    updateThingToDo: actions.update

}
    export default connect(mapStateToProps, mapActionToProps)(ThingToDoForm);
