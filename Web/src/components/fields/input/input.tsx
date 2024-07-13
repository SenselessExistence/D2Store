import React, { useCallback } from 'react';
import { useFormContext} from 'react-hook-form';
import './input.scss';

interface InputProps {
  type: string;
  placeholder: string;
  name: string;
  isRequired?: boolean;
  maxLength?: number;
  minLength?: number;
  pattern?: RegExp;
}
const Input = (props: InputProps) => {

  const { register, formState: {errors} } = useFormContext();

  const getErrorText = useCallback(()=>{
    if (props.type === 'email') {
      return 'Invalid email address';
    } else if (props.type === 'password') {
      return 'Invalid password';
    }
    let text = props.placeholder + ' ';
    if (props.isRequired) {
      text += 'is required ';
    }
    if (props.minLength && props.maxLength){
      text += `and should be ${props.minLength}-${props.maxLength} characters`;
    } else if (props.minLength) {
      text += `and should not be less than ${props.minLength} characters`;
    } else if (props.maxLength) {
      text += `and should not exceed ${props.maxLength} characters`;
    }
    return text
  },[props.type, props.placeholder, props.isRequired, props.maxLength, props.minLength]);
  return (
    <div className='input'>
      <input
        type={props.type}
        placeholder='   '
        {...register(props.name, { required: props.isRequired, maxLength: props.maxLength, pattern: props.pattern, minLength: props.minLength})}
      />
      <label htmlFor={props.name}>{props.placeholder}{props.isRequired ?? '*'}</label>
      <div className='error'>{errors?.[props.name] ? getErrorText() : ''}</div>
    </div>
  );
}

export default Input;