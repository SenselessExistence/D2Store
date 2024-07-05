import React, { useCallback } from 'react';
import { useFormContext} from 'react-hook-form';
import './input.scss';

interface InputProps {
  type: string;
  placeholder: string;
  name: string;
  isRequired?: boolean;
  maxLength?: number;
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
    if (props.maxLength) {
      text += `and should not exceed ${props.maxLength} characters`;
    }
    return text
  },[props.type, props.placeholder, props.isRequired, props.maxLength]);
  return (
    <div className='input'>
      <input
        type={props.type}
        placeholder='   '
        {...register(props.name, { required: props.isRequired, maxLength: props.maxLength, pattern: props.pattern })}
      />
      <label htmlFor={props.name}>{props.placeholder}{props.isRequired ?? '*'}</label>
      <div className='error'>{errors?.[props.name] ? getErrorText() : ''}</div>
    </div>
  );
}

export default Input;