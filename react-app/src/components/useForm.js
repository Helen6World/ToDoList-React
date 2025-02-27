import React, {useState, useEffect} from 'react';
const useFrom=(initialFieldValues, validate, setCurrentId) => {
    const [values,setValues] =useState(initialFieldValues)
    const [errors, setErrors]=useState({})
    const handleInputChange = e => {
        const {name, value} = e.target
        setValues({
            ...values,
            [name]: value
        })
    }
    const resetForm =()=> {
        setValues({
            ...initialFieldValues
        })
        setErrors({})
        setCurrentId(0)
    }
    return {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange,
        resetForm
    };
}
export default useFrom;