import styled from "styled-components";

export const DefaultCommonButtonPanel = styled.div`
    display: flex;
    position: relative;
    margin-bottom: 0.5rem;
    flex-direction: row;
    & > *:not(:last-child) {
        margin-right: 1rem;
    }
`