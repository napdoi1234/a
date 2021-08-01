import axios from "axios";
import CategoryConstant from './../../shared/constants/CategoryConstant';

export function GetCategoriesService(index, size) {
  return axios.get(CategoryConstant.CategoryURL, {
    params: {
      pageSize: size,
      pageIndex: index
    }
  });
};

export function GetCategoryService(id) {
  return axios.get(`${CategoryConstant.CategoryURL}/${id}`);
};

export function CreateCategoryService({ name }) {
  return axios.post(CategoryConstant.CategoryURL, {
    name: name,
  });
}

export function UpdateCategoryService({ id, name }) {
  return axios.put(CategoryConstant.CategoryURL, {
    id: id,
    name: name,
  });
}

export function DeleteCatgoryService(id) {
  return axios.delete(`${CategoryConstant.CategoryURL}/${id}`);
}