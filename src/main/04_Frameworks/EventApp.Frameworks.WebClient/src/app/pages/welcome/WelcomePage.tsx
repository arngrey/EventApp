import React from 'react';
import { CommonTitle } from '../../components/atoms/CommonTitle';
import { FieldForm } from '../../components/organisms/FieldForm';
import { useAppDispatch, useAppSelector } from '../../hooks';
import { signInAsync, signUpAsync } from '../../modules/authentication/slice';
import { WelcomeFormContainer, TitleContainer, WelcomePageContainer } from './WelcomePage.styles';


function WelcomePage() {
    const dispatch = useAppDispatch();

    return (
        <WelcomePageContainer>
            <TitleContainer>
                <CommonTitle
                    text="Campaign Finder" />
            </TitleContainer>
            <WelcomeFormContainer>
                <FieldForm
                    title={"Войти"}
                    fields={[
                        { name: "login", type: "input", props: { labelText: "Логин" } },
                        { name: "password", type: "input", props: { labelText: "Пароль" } },
                    ]}
                    buttons={[
                        { 
                            text: "Войти", 
                            onClick: async (record, history) => {
                                await dispatch(signInAsync(record["login"], record["password"]));
                                history.push("/");
                            }
                        }, { 
                            text: "Зарегистрироваться", 
                            onClick: async (record, history) => { 
                              await dispatch(signUpAsync(record["login"], record["password"]));
                              history.push("/");
                            }
                        }

                    ]} />
            </WelcomeFormContainer>
        </WelcomePageContainer>
    )
}

 export default WelcomePage;